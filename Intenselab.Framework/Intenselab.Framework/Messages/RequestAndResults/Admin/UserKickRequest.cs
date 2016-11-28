// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserKickRequest.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents request for disconnecting user from server.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class UserKickRequest : MessageWithId
    {

        /// <summary>
        ///     Name of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     Initialize the <see cref="UserKickRequest"/> class.
        /// </summary>
        public UserKickRequest()
            : base(0)
        {
        }

        /// <summary>
        ///     Initialize the <see cref="UserKickRequest"/> class with special request Id.
        /// </summary>
        /// <param name="requestId">
        ///     Id of request.
        /// </param>
        public UserKickRequest(int requestId) : 
            base(requestId)
        {}
    }
}
