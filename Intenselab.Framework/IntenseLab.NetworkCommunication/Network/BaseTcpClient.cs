// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseTcpClient.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Helpers;
using IntenseLab.Shared;
using System;
using System.Net.Sockets;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;

namespace IntenseLab.NetworkCommunication.Network
{
    /// <summary>
    ///     Represents base functionality for communicating via network.
    /// </summary>
    public abstract class BaseTcpClient
    {
        /// <summary>
        ///     Size of message header.
        /// </summary>
        private const int PacketHeaderSize = 16;

        /// <summary>
        ///     Error message to notify that packet is to big or it has some unexpected values.
        /// </summary>
        private const string StrongPacketMessage = "Strange packet received";


        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseTcpClient" /> class with specified socket.
        /// </summary>
        /// <param name="socket">
        ///     Socket that will be used for network communication.
        /// </param>
        protected BaseTcpClient(Socket socket)
        {
            var settings = new SocketSettings();
            SetupSocket(socket, settings);
            NetworkClient = new NetworkClient(socket);
        }

        private static void SetupSocket(Socket socket, SocketSettings settings)
        {
            socket.ReceiveTimeout = settings.NetworkClientReceiveTimeout;
            socket.SendTimeout = settings.NetworkClientSendTimeout;
            socket.ReceiveBufferSize = settings.NetworkClientReceiveBufferSize;
            socket.SendBufferSize = settings.NetworkClientSendBufferSize;
            socket.NoDelay = settings.UseNoDelay;

            NetworkHelper.SetKeepAliveValues(socket, true,
                keepAliveTime: (uint)settings.NetworkClientKeepAliveTimeout,
                keepAliveInterval: (uint)settings.NetworkClientKeepAliveInterval);
        }

        /// <summary>
        ///     Send specified <see cref="buffer"/> via network.
        ///     If send operation fail than <see cref="OnTerminated"/> event will be invoked.
        /// </summary>
        /// <param name="buffer">
        ///     Message converted to array of bytes.
        /// </param>
        public void Send(byte[] buffer)
        {
            if (!NetworkClient.TrySendAsync(buffer))
                OnSocketException(NetworkClient.LastSenderException);
        }

        /// <summary>
        ///     Start receive all messages.
        /// </summary>
        public void StartReceive()
        {
            CancellationTokenSource = new CancellationTokenSource();
            ReceiverTask = Task.Factory.StartNew(ReceiveWorker, TaskCreationOptions.LongRunning);
        }

        /// <summary>
        ///     Stop receive all messages an close socket.
        /// </summary>
        public void StopReceive()
        {
            if (!NetworkClient.Connected)
                return;

            NetworkClient.Close();
            CancellationTokenSource.Cancel();
        }
        /// <summary>
        ///     Worker function that will receive and process messages.
        /// </summary>
        private void ReceiveWorker()
        {
            var token = CancellationTokenSource.Token;

            while (!token.IsCancellationRequested)
            {
                DataBuffer headerBuffer;
                if (!NetworkClient.TryReceiveCompletely(PacketHeaderSize, out headerBuffer))
                {
                    OnSocketException(NetworkClient.LastReceiverException);
                    NetworkClient.Close();
                    break;
                }

                uint packetType;
                int packetLength;
                headerBuffer.ReadUInt32(out packetType);
                headerBuffer.ReadInt32(out packetLength);

                uint flags;
                headerBuffer.ReadUInt32(out flags);
                headerBuffer.ReadUInt32(out flags);
                headerBuffer.Dispose();

                if (packetLength < 1 || packetLength > 10 * 1024 * 1024 || flags != 0)
                {
                    throw new ArgumentOutOfRangeException(StrongPacketMessage);
                }

                DataBuffer messageBuffer;
                NetworkClient.TryReceiveCompletely(packetLength, out messageBuffer);
                OnPacketReceived(packetType, messageBuffer.GetBuffer());
            }
        }


        #region Properties and fields

        /// <summary>
        ///     <see cref="NetworkClient"/>
        /// </summary>
        public NetworkClient NetworkClient { get; }
        private CancellationTokenSource CancellationTokenSource { get; set; }
        private Task ReceiverTask { get; set; }


        #endregion

        #region Events

        /// <summary>
        ///     Represents event that will be invoked when any exception occured during receive or send action.
        /// </summary>
        public IObservable<Tuple<BaseTcpClient, Exception>> OnTerminated => OnTerminatedSubject.AsObservable();
        private Subject<Tuple<BaseTcpClient, Exception>> OnTerminatedSubject { get; } = new Subject<Tuple<BaseTcpClient, Exception>>();


        /// <summary>
        ///     Allows to proccess received serialized message.
        /// </summary>
        /// <param name="hashedPacketType">
        ///     CRC32 sum of packet type's Name.
        /// </param>
        /// <param name="buffer">
        ///     Serialized message..
        /// </param>
        public abstract void OnPacketReceived(uint hashedPacketType, byte[] buffer);

        /// <summary>
        ///     Allows to notify subscribers that any exception occured during receive or send action. 
        /// </summary>
        /// <param name="exception">
        ///     Exception that cause failure.
        /// </param>
        protected void OnSocketException(Exception exception)
        {
            OnTerminatedSubject.OnNext(new Tuple<BaseTcpClient, Exception>(this, exception));
        }


        #endregion
    }
}