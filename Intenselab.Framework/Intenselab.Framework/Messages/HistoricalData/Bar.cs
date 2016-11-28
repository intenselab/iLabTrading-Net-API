// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bar.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents one historical bar.
    /// </summary>
    public sealed class Bar
    {
        /// <summary>
        ///     Gets or sets time of bar closing.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        ///     Gets or sets the highest price in current period of time.
        /// </summary>
        public float High { get; set; }

        /// <summary>
        ///     Gets or sets the lowest price in current period of time.
        /// </summary>
        public float Low { get; set; }

        /// <summary>
        ///     Gets or sets first price in current period of time.
        /// </summary>
        public float Open { get; set; }

        /// <summary>
        ///     Gets or sets last price in current period of time.
        /// </summary>
        public float Close { get; set; }

        /// <summary>
        ///     Gets or sets count on traded shares.
        /// </summary>
        public long Volume { get; set; }

        /// <summary>
        ///     <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return $"BAR => Time:{Time} High:{High} Low:{Low} Open:{Open} Close:{Close} Volume:{Volume}";
        }
    }
}