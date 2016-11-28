// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HistoricalDataClient.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Framework.Messages;

namespace IntenseLab.Framework
{
    /// <summary>
    ///     Represents client for historical data.
    /// </summary>
    public class HistoricalDataClient : BaseDataClient
    {
        /// <summary>
        ///     Listener for historical data.
        /// </summary>
        public HistoricalDataListener Events { get; }

        /// <summary>
        ///     Initialize the <see cref="HistoricalDataClient" /> class.
        /// </summary>
        /// <param name="events">
        ///     Listener for historical data.
        /// </param>
        public HistoricalDataClient(HistoricalDataListener events) :
            base(TradingChannel.HistoricalData)
        {
            Events = events;
        }

        /// <summary>
        ///     Send request for historical data.
        /// </summary>
        /// <param name="request">
        ///     Request for historical data.
        /// </param>
        public void SendHistoricalRequest(HistoricalDataRequest request)
        {
            ClientSend(request);
        }
    }
}