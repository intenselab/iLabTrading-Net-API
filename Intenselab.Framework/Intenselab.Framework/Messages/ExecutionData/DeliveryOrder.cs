// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryOrder.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents order for <see cref="CommodityPosition"/> delivery.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class DeliveryOrder : BaseOrder
    {
        /// <summary>
        ///     Original number of order.
        /// </summary>
        public long DeliveryTicketNo { get; set; }

        /// <summary>
        ///     <see cref="CommodityPosition.ReferenceTicketNo"/> of position to delivery.
        /// </summary>
        public long ReferenceTicketNo { get; set; }
    }
}
