// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderType.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents type of the order.
    /// </summary>
    public enum OrderType : byte
    {
        /// <summary>
        ///     Market order.
        /// </summary>
        Mkt,

        /// <summary>
        ///     Limit order.
        /// </summary>
        Lmt,

        /// <summary>
        ///     Stop order.
        /// </summary>
        Stp,

        /// <summary>
        ///     Stop limit order.
        /// </summary>
        StpLmt,

        /// <summary>
        ///     Position close order.
        /// </summary>
        PositionClose,

        /// <summary>
        ///     Order for cancelling all pending orders and close position.
        /// </summary>
        PositionCancelAndClose
    }
}