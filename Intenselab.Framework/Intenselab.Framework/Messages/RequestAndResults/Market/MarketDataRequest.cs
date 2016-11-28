// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarketDataRequest.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Messages;
using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Request on market data.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class MarketDataRequest : BaseMessage
    {
        /// <summary>
        ///     Type of subscription action.
        /// </summary>
        public SubscriptionAction SubscriptionAction { get; set; }

        /// <summary>
        ///     Type of requested market data.
        /// </summary>
        public MarketDataType DataType { get; set; }

        /// <summary>
        ///     Abbreviation for stock name.
        /// </summary>
        public string Symbol { get; set; }
    }
}