// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISenderQueueFactory.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Network;

namespace IntenseLab.NetworkCommunication.Interfaces
{
    /// <summary>
    ///     Universal interface for creating <see cref="IBaseDataClientWithQueue"/> that will transfer data through it's queue and send data using <see cref="QueueTcpClient"/>
    /// </summary>
    public interface ISenderQueueFactory
    {
        /// <summary>
        ///     Create <see cref="IBaseDataClientWithQueue"/> that will transfer data through it's queue and send data using <see cref="QueueTcpClient"/>
        /// </summary>
        /// <param name="tcpClient">
        ///     Client that will be used for sending data via network.
        /// </param>
        /// <returns>
        ///     Created object of type <see cref="IBaseDataClientWithQueue"/>
        /// </returns>
        IBaseDataClientWithQueue CreateSenderQueue(QueueTcpClient tcpClient);
    }
}
