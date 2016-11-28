// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataClientWithQueue.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Interfaces;

namespace IntenseLab.Framework
{
    /// <summary>
    ///     Represents extension for <see cref="IBaseDataClientWithQueue"/>
    /// </summary>
    public interface IDataClientWithQueue : IBaseDataClientWithQueue
    {
        /// <summary>
        ///     Add data to client's queue.
        /// </summary>
        /// <param name="data">
        ///     Item of type <see cref="DataPacket"/> that will be added to client's queue.
        /// </param>
        void EnqueueData(DataPacket data);
    }
}
