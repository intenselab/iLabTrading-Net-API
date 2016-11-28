// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientContext.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using IntenseLab.NetworkCommunication.Helpers;
using IntenseLab.NetworkCommunication.Interfaces;
using IntenseLab.NetworkCommunication.Messages;
using System.Net.Sockets;

namespace IntenseLab.NetworkCommunication.Network
{
    /// <summary>
    ///     Represents a client on the server.
    /// </summary>
    public class ClientContext : QueueTcpClient
    {
        private const string MessageNotValidClient = "Client is not valid.";

        private bool IsValidTradingClient { get; set; }

        /// <summary>
        ///     Initialize new instance of <see cref="ClientContext" /> class.
        /// </summary>
        /// <param name="socket">
        ///     Accepted socket of client.
        /// </param>
        /// <param name="receiverQueue">
        ///     <see cref="IBaseDataClientWithQueue"/>
        /// </param>
        /// <param name="senderQueueFactory">
        ///     <see cref="ISenderQueueFactory"/>
        /// </param>
        public ClientContext(Socket socket, IBaseDataClientWithQueue receiverQueue, ISenderQueueFactory senderQueueFactory)
            : base(socket, receiverQueue, senderQueueFactory)
        {}

        /// <summary>
        ///     Process received and deserialized message.
        /// </summary>
        protected override void ProcessPacket(object packet)
        {
            // on first connection do hand shake procedure
            // if client is not valid -- drop connection
            if (!IsValidTradingClient)
            {
                if (!(packet is HandShakeResponse))
                    throw new InvalidClientException(InvalidClientType.Client, MessageNotValidClient);

                var value = (HandShakeResponse)packet;
                Serializer = IntenseLabFrameworkInitializer.GetPacketSerializerByName(value.PacketSerializer);
                IsValidTradingClient = true;
                DoOnReady();
                return;
            }

            ReceiverQueue.EnqueueData(packet as BaseMessage);
        }
    }
}
