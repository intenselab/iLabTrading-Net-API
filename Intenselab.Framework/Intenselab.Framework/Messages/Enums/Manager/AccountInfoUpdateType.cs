// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HistoricalResponseCode.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents type <see cref="AccountInfo"/> update
    /// </summary>
    [Flags]
    public enum AccountInfoUpdateType
    {
        /// <summary>
        ///     Nothing was updated.
        /// </summary>
        None = 0x0,

        /// <summary>
        ///     Fields that corresponds to account were updated.
        /// </summary>
        AccountInfo = 0x1,

        /// <summary>
        ///      Fields that corresponds to account's risks were updated.
        /// </summary>
        RiskInfo = 0x2,

        /// <summary>
        ///      Fields that corresponds to account's trading statistic were updated.
        /// </summary>
        TradingStatistic = 0x4,

        /// <summary>
        ///     Fields in all nested objects were updated.
        /// </summary>
        All = AccountInfo | RiskInfo | TradingStatistic
    }
}
