// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TradingChannel.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents type of channel.
    /// </summary>
    public enum TradingChannel
    {
        /// <summary>
        ///     Unknown channel.
        /// </summary>
        Unknown,

        /// <summary>
        ///     Authorization channel.
        /// </summary>
        Authorization,

        /// <summary>
        ///     Channel that provides market data.
        /// </summary>
        MarketData,

        /// <summary>
        ///     Channel that provides execution data.
        /// </summary>
        ExecutionData,

        /// <summary>
        ///     Channel that produce historical data.
        /// </summary>
        HistoricalData,
    }
}
