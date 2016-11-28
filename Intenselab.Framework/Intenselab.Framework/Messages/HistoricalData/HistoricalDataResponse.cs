// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HistoricalDataResponse.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Response on <see cref="HistoricalDataRequest"/>
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class HistoricalDataResponse : HistoricalData
    {
        /// <summary>
        ///     Collection of <see cref="Bar"/> objects.
        /// </summary>
        public List<Bar> BarList { get; private set; }

        /// <summary>
        ///     Some additional information about request result.
        /// </summary>
        public string Message { get; }

        /// <summary>
        ///     Result of request
        /// </summary>
        public HistoricalResponseCode ResponseCode { get; }

        /// <summary>
        ///     Collection of <see cref="Tick"/> objects.
        /// </summary>
        public List<Tick> TickList { get; private set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="HistoricalDataResponse" /> class.
        /// </summary>
        public HistoricalDataResponse()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="HistoricalDataResponse" /> class.
        /// </summary>
        /// <param name="requestId">
        ///     Id of received request from client.
        /// </param>
        /// <param name="code">
        ///     Result of request.
        /// </param>
        /// <param name="message">
        ///     Some additional information about request result.
        /// </param>
        public HistoricalDataResponse(long requestId, HistoricalResponseCode code, string message = "")
        {
            RequestId = requestId;
            Message = message;
            ResponseCode = code;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="HistoricalDataResponse" /> class.
        /// </summary>
        /// <param name="requestId">
        ///     Id of received request from client.
        /// </param>
        public HistoricalDataResponse(long requestId)
        {
            RequestId = requestId;
        }

        /// <summary>
        ///     Gets a value indicating whether response has any bar.
        /// </summary>
        public bool HasBars => BarList != null && BarList.Count > 0;

        /// <summary>
        ///     Gets a value indicating whether response has any tick.
        /// </summary>
        public bool HasTicks => TickList != null && TickList.Count > 0;

        /// <summary>
        ///     Set collection of bars to current response.
        /// </summary>
        /// <param name="barCollection">
        ///     Collection of <see cref="Bar"/> objects.
        /// </param>
        public void SetupBars(List<Bar> barCollection)
        {
            BarList = barCollection;
        }

        /// <summary>
        ///     Set collection of ticks to current response.
        /// </summary>
        /// <param name="tickCollection">
        ///     Collection of <see cref="Tick"/> objects.
        /// </param>
        public void SetupTicks(List<Tick> tickCollection)
        {
            TickList = tickCollection;
        }
    }
}