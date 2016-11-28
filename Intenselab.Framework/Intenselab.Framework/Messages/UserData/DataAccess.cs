// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataAccess.cs" company="IntenseLab">
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
    ///     Represents accessibility to specified type of data.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class DataAccess : BaseMessage
    {
        // components access
        /// <summary>
        ///     Gets or sets a value indicating whether access to market data enabled.
        /// </summary>
        public bool MarketDataAccessEnabled { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether access to execution data enabled.
        /// </summary>
        public bool ExecutionDataAccessEnabled { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether access to historical data enabled.
        /// </summary>
        public bool HistoricalDataAccessEnabled { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether access to NYSE imbalance data enabled.
        /// </summary>
        public bool NyseImbalanceDataAccessEnabled { get; set; }
    }
}
