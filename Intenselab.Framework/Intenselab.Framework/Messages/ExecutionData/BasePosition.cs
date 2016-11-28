namespace IntenseLab.Framework.Messages
{
    public abstract class BasePosition : TradingData
    {
        /// <summary>
        ///     Abbreviation for stock name.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        ///     Side of the position.
        /// </summary>
        public OrderSide Side { get; set; }

        /// <summary>
        ///     Count of open shares in position.
        /// </summary>
        public int Shares { get; set; }

        /// <summary>
        ///     Price of the position.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        ///     Value indicating possible income calculated by last quote.
        /// </summary>
        public double Open { get; set; }

        /// <summary>
        ///     Value indicating possible income calculated by last print.
        /// </summary>
        public double OpenPrint { get; set; }

        /// <summary>
        ///     Commission charged for executed orders..
        /// </summary>
        public double Commission { get; set; }

        /// <summary>
        ///     Price of last quote.
        /// </summary>
        public double LastQuotePrice { get; set; }

        /// <summary>
        ///     Price of last print.
        /// </summary>
        public double LastPrintPrice { get; set; }
    }
}
