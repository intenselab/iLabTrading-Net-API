// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderSide.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents side of the order.
    /// </summary>
    public enum OrderSide : byte
    {
        /// <summary>
        ///     None side.
        /// </summary>
        None = (byte)'N',

        /// <summary>
        ///     Buy side.
        /// </summary>
        Buy = (byte)'B',

        /// <summary>
        ///     Sell side.
        /// </summary>
        Sell = (byte)'S'
    }
}