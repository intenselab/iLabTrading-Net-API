// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CancelOrder.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///    Message for canceling bid with specified ticket number.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class CancelOrder : BaseOrder
    {
        /// <summary>
        ///     Gets or sets unique number per one cancel message from <see cref="CancelOrder"/> to <see cref="Canceled"/> or <see cref="CancelReject"/>.
        /// </summary>
        public long CancelTicketNo { get; set; }

        /// <summary>
        ///     <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return $"CancelOrder: CancelTicketNo: {CancelTicketNo}, Account: {AccountName}, ClientOrderId: {ClientOrderId}, TicketNo: {TicketNo}, User: {UserName}, ServerTime: {ServerTime}";
        }


    }
}