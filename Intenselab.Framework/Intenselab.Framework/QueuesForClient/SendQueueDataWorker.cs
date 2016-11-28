// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendQueueDataWorker.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Network;

namespace IntenseLab.Framework
{
    /// <summary>
    ///     Client that will represents sending queue.
    /// </summary>
    public class SendQueueDataWorker : QueueDataWorker
    {
        private QueueTcpClient TcpClient { get; }

        /// <summary>
        ///     Create new instance of <see cref="SendQueueDataWorker"/> 
        ///     with specified TCP client to use it for sending via network.
        /// </summary>
        /// <param name="tcpClient"></param>
        public SendQueueDataWorker(QueueTcpClient tcpClient)
        {
            TcpClient = tcpClient;
        }

        /// <summary>
        ///     <see cref="QueueDataWorker.ProcessDataPacket"/>
        /// </summary>
        protected override void ProcessDataPacket(DataPacket data)
        {
            TcpClient.Send(data.Packet);
        }
    }
}
