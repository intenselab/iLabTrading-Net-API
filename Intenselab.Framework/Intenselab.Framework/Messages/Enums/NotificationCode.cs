// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationCode.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Code of <see cref="SystemNotification"/>ю
    /// </summary>
    public enum NotificationCode
    {
        /// <summary>
        ///     Unknown code.
        /// </summary>
        Unknown,

        /// <summary>
        ///     Value indicate that account is not authorized.
        /// </summary>
        NotAuthorized,

        /// <summary>
        ///     Value indicate that account name is incorrect.
        /// </summary>
        InvalidAccount,

        /// <summary>
        ///     Value indicate that current account has no permission to execute such operation.
        /// </summary>
        AccessDeny,

        /// <summary>
        ///     Value indicate that account is disabled.
        /// </summary>
        AccountIsDisabled,

        /// <summary>
        ///     Value indicate that symbols limit is reached.
        /// </summary>
        Level1SymbolsLimitReached,

        /// <summary>
        ///     Value indicate that symbols limit is reached.
        /// </summary>
        Level2SymbolsLimitReached,

        /// <summary>
        ///     Value indicate that received subscription on null or empty symbol.
        /// </summary>
        SubscriptionOnNullOrEmptySymbol,

        /// <summary>
        ///     Value indicate that message is not supported on server side.
        /// </summary>
        MessageNotSupported,

        /// <summary>
        ///     Value indicate that user connection settings was changed.
        /// </summary>
        UserConnectionSettingsChanged,

        /// <summary>
        ///     Value indicate that connection was failed.
        /// </summary>
        ConnetionFailed,

        /// <summary>
        ///     Notify that client must disconnect from server.
        /// </summary>
        KickUser,

        /// <summary>
        ///     Notify that client was forcibly disconnected from server.
        /// </summary>
        UserWasKicked
    };
}