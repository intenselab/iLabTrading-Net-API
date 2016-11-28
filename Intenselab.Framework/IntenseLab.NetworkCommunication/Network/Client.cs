// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Client.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Helpers;
using IntenseLab.NetworkCommunication.Interfaces;
using IntenseLab.NetworkCommunication.Messages;
using System.Linq;
using System.Net.Sockets;

namespace IntenseLab.NetworkCommunication.Network
{
    /// <summary>
    ///     Represents extension of <see cref="QueueTcpClient"/>.
    /// </summary>
    public class Client : QueueTcpClient
    {
        private const string MessageNotValidServer = "Server in not valid";


        /// <summary>
        ///     Initialize new instance of <see cref="Client" /> class.
        /// </summary>
        /// <param name="receiverQueue">
        ///     <see cref="IBaseDataClientWithQueue"/>
        /// </param>
        /// <param name="senderQueueFactory">
        ///     <see cref="ISenderQueueFactory"/>
        /// </param>
        public Client(IBaseDataClientWithQueue receiverQueue, ISenderQueueFactory senderQueueFactory)
            : base(new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP), receiverQueue, senderQueueFactory)
        { }

        /// <summary>
        ///     Indicates whether trading server is valid
        /// </summary>
        private bool IsValidTradingServer { get; set; }

        /// <summary>
        ///     Indicates whether current client is connected to server.
        /// </summary>
        public bool IsConnected => NetworkClient.Connected;

        /// <summary>
        ///     Process received and deserialized message.
        /// </summary>
        protected override void ProcessPacket(object packet)
        {
            if (!IsValidTradingServer)
            {
                if (!(packet is HandShake))
                    throw new InvalidClientException(InvalidClientType.Server, MessageNotValidServer);

                var handShake = (HandShake)packet;
                var packetSerializer = handShake.PacketSerializers.FirstOrDefault();

                Send(new HandShakeResponse
                {
                    PacketSerializer = packetSerializer
                });

                Serializer = IntenseLabFrameworkInitializer.GetPacketSerializerByName(packetSerializer);
                IsValidTradingServer = true;
                DoOnReady();
                return;
            }

            ReceiverQueue.EnqueueData(packet as BaseMessage);
        }


        /// <summary>
        ///     Connect to specified host and port.
        /// </summary>
        /// <param name="host">
        ///     Server host
        /// </param>
        /// <param name="port">
        ///     Server port
        /// </param>
        /// <param name="rethrowConnectException">
        ///     Option which indicates whether to rethrow exception when connection fail or invoke <see cref="BaseTcpClient.OnTerminated"/> event.
        /// </param>
        public void Connect(string host, int port, bool rethrowConnectException)
        {
            try
            {
                NetworkClient.Connect(host, port);
            }
            catch (SocketException exception)
            {
                if (rethrowConnectException)
                    throw;

                OnSocketException(exception);
                return;
            }

            StartReceive();
        }

        /// <summary>
        ///     Disconnect client from connected server.
        /// </summary>

        public void Disconnect()
        {
            StopReceive();
        }
    }
}
