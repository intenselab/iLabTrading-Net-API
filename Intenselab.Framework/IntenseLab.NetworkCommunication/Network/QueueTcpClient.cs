// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueueTcpClient.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Helpers;
using IntenseLab.NetworkCommunication.Interfaces;
using IntenseLab.NetworkCommunication.Messages;
using IntenseLab.NetworkCommunication.Serializers;
using MsgPack;
using System;
using System.Net.Sockets;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace IntenseLab.NetworkCommunication.Network
{

    /// <summary>
    ///     Represents extension for <see cref="BaseTcpClient"/>.
    ///     Provides separated queues for sending and receiving messages.
    /// </summary>
    public abstract class QueueTcpClient : BaseTcpClient, IBaseDataClientWithQueue
    {
        #region Messages
        private const string MessageUnsupportedPacketType = "Unsupported packet type.";
        #endregion

        #region Queues
        /// <summary>
        ///     Provides client with queue that will receive and process message.
        /// </summary>
        protected IBaseDataClientWithQueue ReceiverQueue { get; }

        /// <summary>
        ///     Provides client with queue that will proccess message and send it using current <see cref="QueueTcpClient"/>
        /// </summary>
        protected IBaseDataClientWithQueue SenderQueue { get; }
        #endregion

        /// <summary>
        ///     Serialize messages before sending and deserialize after receiving.
        /// </summary>
        protected IPacketSerializer Serializer { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="QueueTcpClient" /> class with specified queues.
        /// </summary>
        /// <param name="socket">
        ///     Socket which will be used to send/receive messages.
        /// </param>
        /// <param name="receiverQueue">
        ///     <see cref="IBaseDataClientWithQueue"/>
        /// </param>
        /// <param name="senderQueueFactory">
        ///     <see cref="ISenderQueueFactory"/>
        /// </param>
        protected QueueTcpClient(Socket socket, IBaseDataClientWithQueue receiverQueue, ISenderQueueFactory senderQueueFactory)
            : base(socket)
        {
            Serializer = new JsonPacketSerializer();
            ReceiverQueue = receiverQueue;
            SenderQueue = senderQueueFactory.CreateSenderQueue(this);
        }


        /// <summary>
        ///     Send packet to client.
        /// </summary>
        /// <param name="packet">
        ///     The packet to send.
        /// </param>
        /// <typeparam name="T">
        ///     <see cref="T"/>
        /// </typeparam>
        public void Send<T>(T packet) where T : BaseMessage
        {
            try
            {
                var serializedPacket = Serializer.SerializePacket(packet);
                var header = SerializerHelper.GenerateMessageHeader(packet, serializedPacket.Length);

                var buff = new byte[header.Length + serializedPacket.Length];

                Array.Copy(header, buff, header.Length);
                Array.Copy(serializedPacket, 0, buff, header.Length, serializedPacket.Length);

                base.Send(buff);
            }
            catch (Exception exception)
            {
                OnSocketException(exception);
            }
        }

        /// <summary>
        ///     Process received message.
        /// </summary>
        /// <param name="hashedPacketType">
        ///     CRC32 sum of message type's Name.
        /// </param>
        /// <param name="buffer">
        ///     Received serialized message.
        /// </param>
        public override void OnPacketReceived(uint hashedPacketType, byte[] buffer)
        {
            try
            {
                var packetType = SerializerHelper.ConvertFromHashToPacketType(hashedPacketType);

                if (packetType == null)
                    throw new MessageNotSupportedException(MessageUnsupportedPacketType);

                var packet = Serializer.DeserializePacket(buffer, packetType);
                ProcessPacket(packet);
            }
            catch (InvalidClientException invalidClientException)
            {
                OnSocketException(invalidClientException);
            }
            catch (Exception exception)
            {
                OnExceptionSubject.OnNext(exception);
            }
        }

        /// <summary>
        ///     Process deserialized message.
        /// </summary>
        /// <param name="packet">
        ///     Deserialized message.
        /// </param>
        protected abstract void ProcessPacket(object packet);

        /// <summary>
        ///     Activated when exception occur
        /// </summary>
        public IObservable<Exception> OnException => OnExceptionSubject.AsObservable();

        /// <summary>
        ///     Activated when client is ready
        /// </summary>
        public IObservable<QueueTcpClient> OnReady => OnReadySubject.AsObservable();


        private Subject<Exception> OnExceptionSubject { get; } = new Subject<Exception>();
        private Subject<QueueTcpClient> OnReadySubject { get; } = new Subject<QueueTcpClient>();

        /// <summary>
        ///     Notify subscribers that current client is ready.
        /// </summary>
        protected void DoOnReady()
        {
            OnReadySubject.OnNext(this);
        }


        /// <summary>
        ///     <see cref="IBaseDataClientWithQueue.EnqueueData"/>
        /// </summary>
        public void EnqueueData(BaseMessage data)
        {
            SenderQueue.EnqueueData(data);
        }

        /// <summary>
        ///     Disconnect client with specified exception-reason.
        /// </summary>
        /// <param name="disconnectingReason">
        ///     Exception that cause client force disconnect.
        /// </param>
        public void DisconnectClient(Exception disconnectingReason)
        {
            OnSocketException(disconnectingReason);
        }
    }
}
