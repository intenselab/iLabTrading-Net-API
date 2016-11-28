// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountInfoesResponse.cs" company="IntenseLab">
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
    ///     Represents repsonse on <see cref="AdminRequest"/> with type equals to <see cref="AdminRequestType.AllAccountInfoes"/>
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class AccountInfoesResponse : MessageWithId
    {
        /// <summary>
        ///     Collection of <see cref="AccountInfo"/>.
        /// </summary>
        public List<AccountInfo> AccountInfos { get; set; }

        /// <summary>
        ///     Initialize the <see cref="AccountInfoesResponse"/> class with special request Id.
        /// </summary>
        /// <param name="requestId">
        ///     Id of request.
        /// </param>
        public AccountInfoesResponse(int requestId)
            : base(requestId)
        {
        }

        /// <summary>
        ///     Initialize the <see cref="AccountInfoesResponse"/> class.
        /// </summary>
        public AccountInfoesResponse()
            : base(0)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AccountInfoesResponse" /> class
        ///     with special id of request and collection of <see cref="AccountInfo"/>.
        /// </summary>
        /// <param name="requestId">
        ///     Id of the received request.
        /// </param>
        /// <param name="accountInfos">
        ///     Collection of <see cref="AccountInfo"/>.
        /// </param>
        public AccountInfoesResponse(int requestId, List<AccountInfo> accountInfos)
            : base(requestId)
        {
            AccountInfos = accountInfos;
        }
    }
}
