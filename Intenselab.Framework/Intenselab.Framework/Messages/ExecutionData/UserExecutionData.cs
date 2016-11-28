namespace IntenseLab.Framework.Messages
{
    public abstract class UserExecutionData : TradingData
    {
        /// <summary>
        ///     Get or set name of user.
        /// </summary>
        public string UserName { get; set; }
    }
}
