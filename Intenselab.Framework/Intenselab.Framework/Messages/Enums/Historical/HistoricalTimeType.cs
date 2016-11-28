// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HistoricalTimeType.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents type of minute bars.
    /// </summary>
    public enum HistoricalTimeType
    {
        /// <summary>
        ///     One minute interval.
        /// </summary>
        OneMinute,

        /// <summary>
        ///     Two minute interval.
        /// </summary>
        TwoMinutes,

        /// <summary>
        ///     Five minute interval.
        /// </summary>
        FiveMinutes,

        /// <summary>
        ///     Fifteen minute interval.
        /// </summary>
        FifteenMinutes,

        /// <summary>
        ///     Thirty minute interval.
        /// </summary>
        ThirtyMinutes,

        /// <summary>
        ///     Sixty minute interval.
        /// </summary>
        SixtyMinutes
    }
}