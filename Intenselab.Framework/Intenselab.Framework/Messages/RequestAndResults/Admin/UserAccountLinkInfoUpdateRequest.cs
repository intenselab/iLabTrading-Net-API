// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserAccountLinkInfoUpdateRequest.cs" company="IntenseLab">
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
    ///     Request for updaing links between user and it's accounts.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class UserAccountLinkInfoUpdateRequest : MessageWithId
    {
        /// <summary>
        ///     Initialize the <see cref="UserAccountLinkInfoUpdateRequest"/> class.
        /// </summary>
        public UserAccountLinkInfoUpdateRequest()
            : base(0)
        {
        }

        /// <summary>
        ///     Initialize the <see cref="UserAccountLinkInfoUpdateRequest"/> class with special request Id.
        /// </summary>
        /// <param name="requestId">
        ///     Id of request.
        /// </param>
        public UserAccountLinkInfoUpdateRequest(int requestId)
            : base(requestId)
        {
        }

        /// <summary>
        ///     Names of linked accounts.
        /// </summary>
        public List<string> AccountNames { get; set; }

        /// <summary>
        ///     Name of the user.
        /// </summary>
        public string User { get; set; }
    }
}