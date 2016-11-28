// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SenderQueueFactory.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Interfaces;
using IntenseLab.NetworkCommunication.Network;

namespace IntenseLab.Framework
{
    /// <summary>
    ///     Represents local default implementation of <see cref="ISenderQueueFactory"/>
    /// </summary>
    public class SenderQueueFactory : ISenderQueueFactory
    {
        /// <summary>
        ///     <see cref="ISenderQueueFactory.CreateSenderQueue"/>
        /// </summary>
        public IBaseDataClientWithQueue CreateSenderQueue(QueueTcpClient tcpClient)
        {
            var queue = new SendQueueDataWorker(tcpClient);
            queue.Start();
            return queue;
        }
    }
}
