// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pending.cs" company="IntenseLab">
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
    ///     Message that indicates about sucessfull execution of <see cref="NewOrder"/>.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class Pending : UserExecutionData
    {
        /// <summary>
        ///     Count of shares that were entered by account.
        /// </summary>
        public int EntryShares { get; set; }

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
        ///     Count of shares that are remaining.
        /// </summary>
        public int PendShares { get; set; }

        /// <summary>
        ///     Limit price.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        ///     Market route.
        /// </summary>
        public string Route { get; set; }

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
                $"Pending: TicketNo: {TicketNo}, Account: {AccountName}, Symbol: {Symbol}, Side: {Side}, Route: {Route}, PendShares: {PendShares}, " +
                $"Price: {Price}, StopPrice: {StopPrice}, OrderType: {OrderType}, TimeInForce: {TimeInForce}";
        }
    }
}