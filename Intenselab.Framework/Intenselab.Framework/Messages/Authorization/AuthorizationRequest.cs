// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthorizationRequest.cs" company="IntenseLab">
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
    ///     Represents request on authorization.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class AuthorizationRequest : BaseMessage
    {
        /// <summary>
        ///     Represents user credentials - login and password.
        /// </summary>
        public UserCredentials UserCredentials { get; set; }
    }
}
