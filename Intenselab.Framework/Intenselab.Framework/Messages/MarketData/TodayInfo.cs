// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TodayInfo.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents generalized trading statistic on specified stock.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class TodayInfo : MarketData
    {
        /// <summary>
        ///     Before market closing represents close price of previous day.
        ///     After market closing represents last price of current trading day before market closes.
        /// </summary>
        public double Close { get; set; }

        /// <summary>
        ///     The highest price per current day.
        /// </summary>
        public double High { get; set; }

        /// <summary>
        ///     The lowest price per current day.
        /// </summary>
        public double Low { get; set; }

        /// <summary>
        ///     The first price after market opens.
        /// </summary>
        public double Open { get; set; }

        /// <summary>
        ///     Count of shares traded per current day till current moment.
        /// </summary>
        public long Volume { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TodayInfo" /> class.
        /// </summary>
        public TodayInfo()
            : base(MarketDataType.TodayInfo)
        {
        }

        /// <summary>
        ///     <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return $"TodayInfo: Symbol: {Symbol}, Open: {Open}, Close: {Close}, High: {High}, Low: {Low}, Volume: {Volume}";
        }
    }
}