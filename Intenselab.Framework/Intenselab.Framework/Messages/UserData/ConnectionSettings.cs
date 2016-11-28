// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectionSettings.cs" company="IntenseLab">
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
    ///     Represents connection settings for user.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class ConnectionSettings : BaseMessage
    {
        /// <summary>
        ///     Gets or sets host of server with market data.
        /// </summary>
        public string MarketDataServerHost { get; set; }

        /// <summary>
        ///     Gets or sets port of server with market data.
        /// </summary>
        public int MarketDataServerPort { get; set; }

        /// <summary>
        ///     Gets or sets host of server with execution data.
        /// </summary>
        public string ExecutionDataServerHost { get; set; }

        /// <summary>
        ///     Gets or sets port of server with execution data.
        /// </summary>
        public int ExecutionDataServerPort { get; set; }

        /// <summary>
        ///     Gets or sets host of server with historical data.
        /// </summary>
        public string HistoricalDataServerHost { get; set; }

        /// <summary>
        ///     Gets or sets port of server with execution data.
        /// </summary>
        public int HistoricalDataServerPort { get; set; }
    }
}
