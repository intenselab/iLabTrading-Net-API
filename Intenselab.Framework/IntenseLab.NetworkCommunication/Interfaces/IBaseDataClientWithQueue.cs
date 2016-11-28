// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBaseDataClientWithQueue.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using IntenseLab.NetworkCommunication.Messages;

namespace IntenseLab.NetworkCommunication.Interfaces
{
    /// <summary>
    ///     Universal interface for data transfer to any class of customer who can receive data .
    /// </summary>
    public interface IBaseDataClientWithQueue
    {
        /// <summary>
        ///     Add data to client's queue.
        /// </summary>
        /// <param name="data">
        ///     Item of type <see cref="BaseMessage"/> that will be added to client's queue.
        /// </param>
        void EnqueueData(BaseMessage data);
    }
}