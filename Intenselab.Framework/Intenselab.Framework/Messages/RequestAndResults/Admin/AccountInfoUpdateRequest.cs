// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountInfoUpdateRequest.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Request for updaing account's information.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class AccountInfoUpdateRequest : MessageWithId
    {
        /// <summary>
        ///     Information about account.
        /// </summary>
        public AccountInfo AccountInfo { get; set; }

        /// <summary>
        ///     Initialize the <see cref="AccountInfoUpdateRequest"/> class.
        /// </summary>
        public AccountInfoUpdateRequest()
            : base(0)
        {
        }

        /// <summary>
        ///     Initialize the <see cref="AccountInfoUpdateRequest"/> class with special request Id.
        /// </summary>
        /// <param name="requestId">
        ///     Id of request.
        /// </param>
        public AccountInfoUpdateRequest(int requestId)
            : base(requestId)
        {
        }
    }
}