namespace IntenseLab.Framework.Messages
{
    public abstract class BaseTrade : UserExecutionData
    {
        /// <summary>
        ///     Price that was entered by client.
        /// </summary>
        public double EntryPrice { get; set; }

        /// <summary>
        ///     Count of shares that was entered by client.
        /// </summary>
        public int EntryShares { get; set; }

        /// <summary>
        ///     Price which <see cref="Pending"/> was executed on.
        /// </summary>
        public double ExecPrice { get; set; }

        /// <summary>
        ///     Count of shares that was executed.
        /// </summary>
        public int ExecShares { get; set; }

        /// <summary>
        ///     Market method.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        ///     Type of the order.
        /// </summary>
        public OrderType OrderType { get; set; }

        /// <summary>
        ///     Count of shares that reamin for execution.
        /// </summary>
        public int RemainShares { get; set; }

        /// <summary>
        ///     Market route.
        /// </summary>
        public string Route { get; set; }

        /// <summary>
        ///     Side of the order.
        /// </summary>
        public OrderSide Side { get; set; }

        /// <summary>
        ///     Abbreviation for stock name.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        ///     Commission sum for current trade.
        /// </summary>
        public double Commission { get; set; }
    }
}
