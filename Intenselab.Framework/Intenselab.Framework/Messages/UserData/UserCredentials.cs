// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserCredentials.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Messages;
using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents credentials of user.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class UserCredentials : BaseMessage
    {
        /// <summary>
        ///     Name of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     Password for curret user.
        /// </summary>
        public string Password { get; set; }
    }
}
