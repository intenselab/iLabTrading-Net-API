// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExecutionCancelMessage.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///    Represents base message for all cancel messages.
    /// </summary>
    public abstract class ExecutionCancelMessage : UserExecutionData
    {
        /// <summary>
        ///     Gets or sets unique number per one cancel message from <see cref="CancelOrder"/> to <see cref="Canceled"/> or <see cref="CancelReject"/>.
        /// </summary>
        public long CancelTicketNo { get; set; }

        /// <summary>
        ///     Get or set number of transaction.
        /// </summary>
        public Guid TransactionNo { get; set; }
    }
}