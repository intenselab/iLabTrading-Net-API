// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthorizationSuccessResponse.cs" company="IntenseLab">
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
    ///     Rerpesents response on authorization request when authorization was successul.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class AuthorizationSuccessResponse : BaseMessage
    {
        /// <summary>
        ///     Information about user and it's permissions.
        /// </summary>
        public UserInfo UserInfo { get; set; }

        /// <summary>
        ///     Represents server channel that send response.
        /// </summary>
        public TradingChannel Channel { get; set; }
    }
}