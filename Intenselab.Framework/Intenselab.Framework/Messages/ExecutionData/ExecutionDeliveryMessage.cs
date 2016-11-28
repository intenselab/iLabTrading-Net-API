// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExecutionDeliveryMessage.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents base class for delivery messages.
    /// </summary>
    public abstract class ExecutionDeliveryMessage : UserExecutionData
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
