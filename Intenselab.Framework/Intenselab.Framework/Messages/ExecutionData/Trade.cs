// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trade.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Message that indicates about sucessfull execution of <see cref="Pending"/>.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class Trade : BaseTrade
    {
        
        /// <summary>
        ///     Match number.
        /// </summary>
        public long MatchNo { get; set; }

        /// <summary>
        ///     Number of transaction.
        /// </summary>
        public Guid TransactionNo { get; set; }

        /// <summary>
        ///     Earnings for current trade.
        /// </summary>
        public double Pnl { get; set; }

        /// <summary>
        ///     <see cref="object.ToString"/>.
        /// </summary>
        public override string ToString()
        {
            return
                $"Trade: TicketNo: {TicketNo}, MatchNo: {MatchNo}, Account: {AccountName}, Symbol: {Symbol}, Side: {Side}, ExecShares: {ExecShares}," +
                $" RemainShares: {RemainShares}, ExecPrice: {ExecPrice}, OrderType: {OrderType}";
        }
    }
}