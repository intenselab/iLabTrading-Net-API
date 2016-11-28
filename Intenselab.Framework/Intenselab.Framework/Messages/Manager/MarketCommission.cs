// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarketCommission.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents information about market commission rates
    /// </summary>
    public struct MarketCommission
    {
        /// <summary>
        ///     Type of the commission
        /// </summary>
        public CommisionType CommisionType;

        /// <summary>
        ///     Commission rate
        /// </summary>
        public double Rate;
    }

    /// <summary>
    ///     Types of market commissions
    /// </summary>
    public enum CommisionType
    {
        /// <summary>
        ///     No commission.
        /// </summary>
        None,
        /// <summary>
        ///     Commission charged for one share.
        /// </summary>
        PerShare,

        /// <summary>
        ///     Commission charged for one ticket.
        /// </summary>
        PerTicket,
        /// <summary>
        ///     Commission charged for one trade.
        /// </summary>
        PerTrade
    }
}
