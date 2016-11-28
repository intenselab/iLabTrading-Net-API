// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarketData.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Messages;
using System;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents base class with set of properties for all market data.
    /// </summary>
    public abstract class MarketData : BaseMessage
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MarketData" /> class with specified <see cref="dataType"/>.
        /// </summary>
        /// <param name="dataType">
        ///     Type of market data.
        /// </param>
        protected MarketData(MarketDataType dataType)
        {
            Type = dataType;
        }

        /// <summary>
        ///     Type of market data.
        /// </summary>
        public MarketDataType Type { get; private set; }

        /// <summary>
        ///     Represents abbreviation for stock name.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        ///     Gets or sets time of message from market.
        /// </summary>
        public DateTime Time { get; set; }
    }
}
