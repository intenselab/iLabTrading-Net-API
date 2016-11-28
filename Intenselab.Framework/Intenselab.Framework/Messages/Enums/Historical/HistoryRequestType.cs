// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HistoryRequestType.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents type of requested bars.
    /// </summary>
    public enum HistoryRequestType
    {
        /// <summary>
        ///     Ticks
        /// </summary>
        Tick,

        /// <summary>
        ///     Minute bars.
        /// </summary>
        BarMinute,

        /// <summary>
        ///     Daily bars.
        /// </summary>
        BarDaily,

        /// <summary>
        ///     Weekly bars.
        /// </summary>
        BarWeekly,

        /// <summary>
        ///     Monthly bars.
        /// </summary>
        BarMonthly
    }
}