// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HistoricalDataRequest.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents request on historical data.
    /// </summary>

    [Export]
    [IntenseLabPacket]
    public sealed class HistoricalDataRequest : HistoricalData
    {
        /// <summary>
        ///     Abbreviation for stock name.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        ///     Gets or sets date and time from which to start to compose response.
        /// </summary>
        public DateTime BeginDateTime { get; set; }

        /// <summary>
        ///     Gets or sets date and time at which to end to compose response.
        /// </summary>
        public DateTime EndDateTime { get; set; }

        /// <summary>
        ///     Gets or sets begin time for each day by which data will be filtered.
        /// </summary>
        public TimeSpan BeginFilterTime { get; set; }

        /// <summary>
        ///     Gets or sets end time for each day by which data will be filtered.
        /// </summary>
        public TimeSpan EndFilterTime { get; set; }

        /// <summary>
        ///     Gets or sets type of requested data.
        /// </summary>
        public HistoryRequestType RequestType { get; set; }

        /// <summary>
        ///     Gets or sets parameter for minute bars.
        /// </summary>
        public int RequestTypeParam { get; set; }

        /// <summary>
        ///     Check if requested data must be ticks.
        /// </summary>
        /// <returns>
        ///     Return TRUE when <see cref="RequestType"/> equals to <see cref="HistoryRequestType.Tick"/>.
        ///     In other case return FALSE.
        /// </returns>
        public bool IsTick()
        {
            return RequestType == HistoryRequestType.Tick;
        }

        /// <summary>
        ///     Check if requested data must be bar of any bar type.
        /// </summary>
        /// <returns>
        ///     Return TRUE when <see cref="RequestType"/> not equals to <see cref="HistoryRequestType.Tick"/>.
        ///     In other case return FALSE.
        /// </returns>
        public bool IsBar()
        {
            return RequestType != HistoryRequestType.Tick;
        }
    }
}