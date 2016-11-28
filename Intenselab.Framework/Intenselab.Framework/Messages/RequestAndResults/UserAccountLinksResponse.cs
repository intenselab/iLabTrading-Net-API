// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserAccountLinksResponse.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents repsonse on <see cref="AdminRequest"/> with type equals to <see cref="AdminRequestType.AllUserAccountLinks"/>
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class UserAccountLinksResponse : MessageWithId
    {
        /// <summary>
        ///     Collection of <see cref="UserAccountLinkInfo"/>.
        /// </summary>
        public List<UserAccountLinkInfo> Accounts { get; set; }

        /// <summary>
        ///     Initialize new instance of the <see cref="UserAccountLinksResponse"/> class with special requestId and user - account link.
        /// </summary>
        public UserAccountLinksResponse()
            : base(0)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserAccountLinksResponse" /> class with specified collection of
        ///     <see cref="UserAccountLinkInfo"/> and Id of received request.
        /// </summary>
        /// <param name="requestId">
        ///     Id of the received request.
        /// </param>
        /// <param name="userAccountsLink">
        ///     Linked account names for requested user.
        /// </param>
        public UserAccountLinksResponse(int requestId, UserAccountLinkInfo userAccountsLink)
            : this(requestId, new List<UserAccountLinkInfo> {userAccountsLink})
        {
        }

        /// <summary>
        ///     Initialize a new instance of the <see cref="UserAccountLinksResponse"/> class with special requestId and user - account links collection.
        /// </summary>
        /// <param name="requestId">
        ///     The id of request.
        /// </param>
        /// <param name="userAccountsLinkCollection">
        ///     The collection of user - account links.
        /// </param>
        public UserAccountLinksResponse(int requestId, List<UserAccountLinkInfo> userAccountsLinkCollection)
            : base(requestId)
        {
            Accounts = userAccountsLinkCollection;
        }

        /// <summary>
        ///     <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            var b = new StringBuilder();

            b.Append($"RequestId: {RequestId}\r\n\r\n Content:\r\n\r\n");
            foreach (var acc in Accounts)
            {
                b.Append(acc);
                b.Append("\r\n--------------------\r\n");
            }
            return b.ToString();
        }
    }
}