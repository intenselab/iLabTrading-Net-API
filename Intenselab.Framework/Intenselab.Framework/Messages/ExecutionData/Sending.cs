// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sending.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Message indicating that server side accept <see cref="NewOrder"/>.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class Sending : UserExecutionData
    {
        /// <summary>
        ///     Get or set order id received in <see cref="NewOrder"/> client.
        /// </summary>
        public long ClientOrderId { get; set; }

        /// <summary>
        ///     Value indicating whether bid should be shown as <see cref="Level2"/>.
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        ///     Market method.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        ///     Type of the order.
        /// </summary>
        public OrderType OrderType { get; set; }

        /// <summary>
        ///     Limit price.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        ///     Market route.
        /// </summary>
        public string Route { get; set; }

        /// <summary>
        ///     Accepted shares count.
        /// </summary>
        public int Shares { get; set; }

        /// <summary>
        ///     Side of the order.
        /// </summary>
        public OrderSide Side { get; set; }

        /// <summary>
        ///     Stop price.
        /// </summary>
        public double StopPrice { get; set; }

        /// <summary>
        ///     Abbreviation for stock name.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        ///     Period of time of order topicality before execution or cancelling.
        /// </summary>
        public TimeInForce TimeInForce { get; set; }

        /// <summary>
        ///     Number of transaction.
        /// </summary>
        public Guid TransactionNo { get; set; }

        /// <summary>
        ///     <see cref="object.ToString"/>.
        /// </summary>
        public override string ToString()
        {
            return
                $"Sending: ClientOrderId: {ClientOrderId}, TicketNo: {TicketNo}, Account: {AccountName}, Symbol: {Symbol}, Side: {Side}," +
                $" Shares: {Shares}, OrderType: {OrderType}, Price: {Price}, StopPrice: {StopPrice}";
        }
    }
}