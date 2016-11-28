// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExecutionHistoryRequest.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents request on account's execution history
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class ExecutionHistoryRequest : MessageWithId
    {
        /// <summary>
        ///     Name of the account.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        ///     Type of the requested execution history.
        /// </summary>
        public ExecutionHistoryRequestType ExecutionHistoryRequestType { get; set; }

        /// <summary>
        ///     Initialize the <see cref="ExecutionHistoryRequest"/> class.
        /// </summary>
        public ExecutionHistoryRequest()
            : base(0)
        {
        }

        /// <summary>
        ///     Initialize the <see cref="ExecutionHistoryRequest"/> class with special request id.
        /// </summary>
        /// <param name="requestId">
        ///     The id of request.
        /// </param>
        public ExecutionHistoryRequest(int requestId)
            : base(requestId)
        {
        }
    }
}