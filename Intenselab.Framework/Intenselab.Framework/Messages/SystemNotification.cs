// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemNotification.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents some additional information about results of requests, connection stauses and other.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class SystemNotification : MessageWithId
    {
        /// <summary>
        ///     Channel from which notification was received.
        /// </summary>
        public TradingChannel Channel { get; set; }
        /// <summary>
        ///     Code of the notification.
        /// </summary>
        public NotificationCode NotificationCode { get; set; }

        /// <summary>
        ///     Text message of the notification.
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        ///     Initialize the <see cref="SystemNotification"/> class.
        /// </summary>
        public SystemNotification()
            : base(0)
        {
        }

        /// <summary>
        ///     Initialize the <see cref="SystemNotification"/> class with special id.
        /// </summary>
        /// <param name="requestId">
        ///     Id of request.
        /// </param>
        public SystemNotification(int requestId)
            : base(requestId)
        {
        }

        /// <summary>
        ///     Initialize the <see cref="SystemNotification"/> class with special id, message and notification code..
        /// </summary>
        /// <param name="request">
        ///     Request on which notification will be sent.
        /// </param>
        /// <param name="code">
        ///     Code of notification.
        /// </param>
        /// <param name="message">
        ///     Message of the notification
        /// </param>
        public SystemNotification(MessageWithId request, NotificationCode code, string message)
            : this(message, code, request.RequestId)
        {
        }

        /// <summary>
        ///     Initialize the <see cref="SystemNotification"/> class with special id and notification code..
        /// </summary>
        /// <param name="request">
        ///     Request on which notification will be sent.
        /// </param>
        /// <param name="code">
        ///     Code of notification.
        /// </param>
        public SystemNotification(MessageWithId request, NotificationCode code)
            : this(code, request.RequestId)
        {
        }
        /// <summary>
        ///     Initialize the <see cref="SystemNotification"/> class with special id and notification code..
        /// </summary>
        /// <param name="notificationCode">
        ///     Code of notification.
        /// </param>
        /// <param name="requestId">
        ///     Id of received request.
        /// </param>
        public SystemNotification(NotificationCode notificationCode, int requestId) 
            : base(requestId)
        {
            NotificationCode = notificationCode;
        }

        /// <summary>
        ///     Initialize the <see cref="SystemNotification"/> class with special id, message and notification code..
        /// </summary>
        /// <param name="message">
        ///     Message of the notification
        /// </param>
        /// <param name="notificationCode">
        ///     Code of notification.
        /// </param>
        /// <param name="requestId">
        ///     Id of received request.
        /// </param>
        public SystemNotification(string message, NotificationCode notificationCode, int requestId)
            : this(message, notificationCode)
        {
            RequestId = requestId;
        }

        /// <summary>
        ///     Initialize the <see cref="SystemNotification"/> class with message and notification code..
        /// </summary>
        /// <param name="message">
        ///     Message of the notification
        /// </param>
        /// <param name="notificationCode">
        ///     Code of notification.
        /// </param>
        public SystemNotification(string message, NotificationCode notificationCode)
            : base(0)
        {
            Text = message;

            NotificationCode = notificationCode;
        }
    }
}