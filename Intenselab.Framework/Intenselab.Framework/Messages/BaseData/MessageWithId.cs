// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageWithId.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Messages;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents base class with set of properties for all requests.
    /// </summary>
    public abstract class MessageWithId : BaseMessage
    {
        /// <summary>
        ///     Id of request.
        /// </summary>
        public int RequestId { get; set; }

        /// <summary>
        ///     Create new instance of <see cref="MessageWithId"/> with specified id.
        /// </summary>
        /// <param name="requestId">
        ///     Id of request.
        /// </param>
        protected MessageWithId(int requestId)
        {
            RequestId = requestId;
        }
    }
}