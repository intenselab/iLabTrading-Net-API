// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserCreationRequest.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.Composition;
using IntenseLab.Shared.Attributes;

namespace IntenseLab.Framework.Messages
{

    /// <summary>
    ///     Represents request for creating new user.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class UserCreationRequest : MessageWithId
    {
        /// <summary>
        ///     Create new instance of <see cref="UserCreationRequest"/>
        /// </summary>
        public UserCreationRequest()
            : this(requestId: 0)
        {
            
        }

        /// <summary>
        ///     Create new instance of <see cref="UserCreationRequest"/> with specified id.
        /// </summary>
        /// <param name="requestId">
        ///     Id of request.
        /// </param>
        public UserCreationRequest(int requestId)
            : base(requestId)
        {
            UserInfo = new UserInfo();
            AccountInfo = new AccountInfo();
        }

        /// <summary>
        ///     Information about account.
        /// </summary>
        public AccountInfo AccountInfo { get; set; }

        /// <summary>
        ///     Information about user.
        /// </summary>
        public UserInfo UserInfo { get; set; }
    }
}