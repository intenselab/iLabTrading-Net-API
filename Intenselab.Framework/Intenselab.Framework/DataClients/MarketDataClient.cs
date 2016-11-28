// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarketDataClient.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Framework.Messages;

namespace IntenseLab.Framework
{
    /// <summary>
    ///     Represents client for market data.
    /// </summary>
    public class MarketDataClient : BaseDataClient
    {
        /// <summary>
        ///     Listener for market data.
        /// </summary>
        public MarketDataListener Events { get; }

        /// <summary>
        ///     Initialize the <see cref="MarketDataClient" /> class.
        /// </summary>
        /// <param name="events">
        ///     Listener for market data.
        /// </param>
        public MarketDataClient(MarketDataListener events) :
            base(TradingChannel.MarketData)
        {
            Events = events;
        }

        /// <summary>
        ///     Send request for market data.
        /// </summary>
        /// <param name="request">
        ///     Request for market data.
        /// </param>
        public void SendMarketDataRequest(MarketDataRequest request)
        {
            ClientSend(request);
        }
        
    }
}