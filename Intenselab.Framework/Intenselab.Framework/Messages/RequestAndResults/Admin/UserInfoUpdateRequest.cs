// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserInfoUpdateRequest.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Request for updaing user's information.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class UserInfoUpdateRequest : MessageWithId
    {
        /// <summary>
        ///     Information about user.
        /// </summary>
        public UserInfo UserInfo { get; set; }

        /// <summary>
        ///     Initialize the <see cref="UserInfoUpdateRequest"/> class.
        /// </summary>
        public UserInfoUpdateRequest()
            : base(0)
        {
        }

        /// <summary>
        ///     Initialize the <see cref="UserInfoUpdateRequest"/> class with special request Id.
        /// </summary>
        /// <param name="requestId">
        ///     Id of request.
        /// </param>
        public UserInfoUpdateRequest(int requestId)
            : base(requestId)
        {
        }
    }
}