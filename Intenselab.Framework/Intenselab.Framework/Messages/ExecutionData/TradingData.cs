namespace IntenseLab.Framework.Messages
{
    public class TradingData : ExecutionData
    {
        /// <summary>
        ///     Gets or sets name of broker account.
        /// </summary>
        public string BrokerAccountName { get; set; }

        /// <summary>
        ///     Gets or sets some additional info of broker.
        /// </summary>
        public string BrokerInfo { get; set; }

        /// <summary>
        ///     Gets or sets unique number per one ticket. For cancel messages it represents number of bid that should be canceled.
        /// </summary>
        public long TicketNo { get; set; }

        /// <summary>
        ///     Gets or sets id for sorting accounts activity.
        /// </summary>
        public int ActivityOrderId { get; set; }

        
    }
}
