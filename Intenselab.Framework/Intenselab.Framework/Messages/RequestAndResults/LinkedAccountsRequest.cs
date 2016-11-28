// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinkedAccountsRequest.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents request on linked accounts to current user.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class LinkedAccountsRequest : MessageWithId
    {
        /// <summary>
        ///     Initialize the <see cref="LinkedAccountsRequest"/> class.
        /// </summary>
        public LinkedAccountsRequest()
            : base(0)
        {
        }

        /// <summary>
        ///     Initialize the <see cref="LinkedAccountsRequest"/> class with special request Id.
        /// </summary>
        /// <param name="requestId">
        ///     Id of request.
        /// </param>
        public LinkedAccountsRequest(int requestId)
            : base(requestId)
        {
        }
    }
}