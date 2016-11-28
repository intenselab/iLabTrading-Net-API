// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthorizationFailedResponse.cs" company="IntenseLab">
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
    ///     Rerpesents response on authorization request when authorization fail.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class AuthorizationFailedResponse : BaseMessage
    {
        #region Messages

        private const string IncorrectUserNameMessage = "Incorrect [Username]";
        private const string IncorrectPasswordMessage = "Incorrect [Password]";
        private const string UserIsDisabledMessage = "User is disabled";
        private const string UserIsActiveMessage = "User is active";
        private const string AuthotizationServerIsNotAccessibleMessage = "Can't connect to authorization server";

        #endregion

        /// <summary>
        ///     Create new instane of <see cref="AuthorizationFailedResponse"/>.
        /// </summary>
        public AuthorizationFailedResponse()
        {
            Message = null;
        }

        /// <summary>
        ///     Create new instance of <see cref="AuthorizationFailedResponse"/> with specified fail reason and fill appropriate error message.
        /// </summary>
        /// <param name="reason">
        ///     Reason of authorization request failure.
        /// </param>
        /// <param name="channel">
        ///     Represents server channel that send response.
        /// </param>
        public AuthorizationFailedResponse(FailedAuthorizationReason reason, TradingChannel channel)
        {
            FailedReason = reason;
            Message = GetMessageByFailedReason(FailedReason);
            Channel = channel;
        }

        /// <summary>
        ///     Reason of authorization request failure.
        /// </summary>
        public FailedAuthorizationReason FailedReason { get; set; }

        /// <summary>
        ///     Represents server channel that send response.
        /// </summary>
        public TradingChannel Channel { get; set; }

        /// <summary>
        ///     Error message of authorization request failure.
        /// </summary>
        public string Message { get; set; }

        private static string GetMessageByFailedReason(FailedAuthorizationReason failedAuthorizationReason)
        {
            switch (failedAuthorizationReason)
            {
                case FailedAuthorizationReason.AuthorizationServerIsNotAccessible:
                    return AuthotizationServerIsNotAccessibleMessage;
                case FailedAuthorizationReason.IncorrectPassword:
                    return IncorrectPasswordMessage;
                case FailedAuthorizationReason.IncorrectUserName:
                    return IncorrectUserNameMessage;
                case FailedAuthorizationReason.UserIsAcive:
                    return UserIsActiveMessage;
                case FailedAuthorizationReason.UserIsDisabled:
                    return UserIsDisabledMessage;
            }
            
            return string.Empty;
        }


    }
}
