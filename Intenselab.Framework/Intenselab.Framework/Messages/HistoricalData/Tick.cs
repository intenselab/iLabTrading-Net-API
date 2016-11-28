// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tick.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents one trade in historical data.
    /// </summary>
    public sealed class Tick
    {
        /// <summary>
        ///     Gets or sets time of trade.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        ///     Gets or sets the price of trade.
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        ///     Gets or sets count of shares in trade.
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        ///     <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return $"TICK => Time:{Time} LastPrice:{Price} LastSize:{Size}";
        }
    }
}