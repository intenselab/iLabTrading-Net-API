// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExecutionHistoryResponse.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents response on <see cref="ExecutionHistoryRequest"/>
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class ExecutionHistoryResponse : MessageWithId
    {
        /// <summary>
        ///     Represents requested account's execution history.
        /// </summary>
        public ExecutionHistory ExecutionHistory { get; set; }

        /// <summary>
        ///     Requested type of account's execution history.
        /// </summary>
        public ExecutionHistoryRequestType ExecutionHistoryRequestType { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExecutionHistoryResponse" /> class.
        /// </summary>
        public ExecutionHistoryResponse()
            : base(0)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExecutionHistoryResponse" /> class with a id of received request.
        /// </summary>
        /// <param name="requestId">
        ///     The request id.
        /// </param>
        public ExecutionHistoryResponse(int requestId)
            : base(requestId)
        {
            ExecutionHistory = new ExecutionHistory();
        }
    }
}