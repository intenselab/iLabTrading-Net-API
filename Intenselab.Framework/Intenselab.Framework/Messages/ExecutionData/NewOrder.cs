// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Order.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents new order from client.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class NewOrder : BaseOrder
    {
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
        ///     Limit price of the order.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        ///     Market route.
        /// </summary>
        public string Route { get; set; }

        /// <summary>
        ///     Count of shares.
        /// </summary>
        public int Shares { get; set; }

        /// <summary>
        ///     Side of the order.
        /// </summary>
        public OrderSide Side { get; set; }

        /// <summary>
        ///     Stop limit price.
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
        ///     <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return $"Order: {AccountName};{Symbol};{Side};{Shares};{Price};{OrderType};{ServerTime}";
        }
    }
}