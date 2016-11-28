// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserInfoesResponse.cs" company="IntenseLab">
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
    ///     Represents repsonse on <see cref="AdminRequest"/> with type equals to <see cref="AdminRequestType.AllUserInfoes"/>
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class UserInfoesResponse : MessageWithId
    {
        /// <summary>
        ///     Collection of <see cref="UserInfo"/>.
        /// </summary>
        public List<UserInfo> UsersList { get; set; }

        /// <summary>
        ///     Initialize new instance of the <see cref="UserInfoesResponse"/> class.
        /// </summary>
        public UserInfoesResponse()
            : base(0)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserInfoesResponse" /> class with specified collection of
        ///     <see cref="UserInfo"/> and Id of received request.
        /// </summary>
        /// <param name="requestId">
        ///     Id of the received request.
        /// </param>
        /// <param name="userInfoList">
        ///     Collection of <see cref="UserInfo"/>.
        /// </param>
        public UserInfoesResponse(int requestId, List<UserInfo> userInfoList)
            : base(requestId)
        {
            RequestId = requestId;
            UsersList = userInfoList;
        }
    }
}