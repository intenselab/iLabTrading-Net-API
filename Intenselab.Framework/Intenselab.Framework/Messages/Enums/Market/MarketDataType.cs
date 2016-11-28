// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarketDataType.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Type of market data object.
    /// </summary>
    [Flags]
    public enum MarketDataType
    {
        /// <summary>
        ///     Not defined data type.
        /// </summary>
        Unknown = 0x0,

        /// <summary>
        ///     Level2
        /// </summary>
        Level2 = 0x1,

        /// <summary>
        ///     Level1 Print.
        /// </summary>
        Print = 0x2,

        /// <summary>
        ///     Level1 Quote.
        /// </summary>
        Quote = 0x4,

        /// <summary>
        ///     Level1 Today Info.
        /// </summary>
        TodayInfo = 0x8,

        /// <summary>
        ///     The NYSE imbalance.
        /// </summary>
        NyseImbalance = 0x20,

        /// <summary>
        ///     Level2 Cache.
        /// </summary>
        Level2Cache = 0x40,

        // 0x80
        /// <summary>
        ///     Level2 + Level1 data.
        /// </summary>
        All = Level2 | Print | Quote | TodayInfo
    }
}
