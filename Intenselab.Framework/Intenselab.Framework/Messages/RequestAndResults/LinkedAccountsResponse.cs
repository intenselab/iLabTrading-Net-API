// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinkedAccountsResponse.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents repsonse on <see cref="LinkedAccountsRequest"/>
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class LinkedAccountsResponse : MessageWithId
    {
        /// <summary>
        ///     Collection of accounts' information for linked accounts.
        /// </summary>
        public List<AccountInfo> AccountsInfoes { get; set; }

        /// <summary>
        ///     Collection of connection statuses of linked accounts.
        /// </summary>
        public List<ExecutorAccountConnectionStatus> ConnectionStatuses { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="LinkedAccountsResponse" /> class.
        /// </summary>
        public LinkedAccountsResponse()
            : base(0)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="LinkedAccountsResponse" /> class with Id of received request,
        ///     specified collection of <see cref="AccountInfo"/> and specified collection of <see cref="ExecutorAccountConnectionStatus"/>.
        /// </summary>
        /// <param name="requestId">
        ///     Id of the received request.
        /// </param>
        /// <param name="accountsInfoes">
        ///     Collection of <see cref="AccountInfo"/>.
        /// </param>
        /// <param name="connectionStatuses">
        ///     Collection of <see cref="ExecutorAccountConnectionStatus"/>.
        /// </param>
        public LinkedAccountsResponse(
            int requestId,
            List<AccountInfo> accountsInfoes,
            List<ExecutorAccountConnectionStatus> connectionStatuses = null)
            : base(requestId)
        {
            AccountsInfoes = accountsInfoes;
            ConnectionStatuses = connectionStatuses;
        }
    }
}