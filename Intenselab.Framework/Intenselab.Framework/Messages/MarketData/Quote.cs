// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Quote.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents composed bids by best book price on one of sides.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class Quote : MarketData
    {
        /// <summary>
        ///     Composed exchange.
        /// </summary>
        public string Exchange { get; set; }

        /// <summary>
        ///     Reason of updating.
        /// </summary>
        public QuoteUpdateReason UpdateReason { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Quote" /> class.
        /// </summary>
        public Quote()
            : base(MarketDataType.Quote)
        {
        }

        /// <summary>
        ///     Gets or sets price of composed bid.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        ///     Gets or sets count of shares in composed bid.
        /// </summary>
        public int Shares { get; set; }

        /// <summary>
        ///     <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return $"Quote:{Symbol},{UpdateReason},{Time},{Price},{Shares}";
        }
    }
}