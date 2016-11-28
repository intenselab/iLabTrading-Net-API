// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommodityTrade.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Message that indicates about sucessfull execution of <see cref="Pending"/> on commodity routes.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class CommodityTrade : BaseTrade
    {
        /// <summary>
        ///     TicketNo of correspond trade.
        /// </summary>
        public long ReferenceTicketNo { get; set; }

        /// <summary>
        ///     Name of correspond account.
        /// </summary>
        public string ReferenceAccountName { get; set; }

        /// <summary>
        ///     <see cref="object.ToString"/>.
        /// </summary>
        public override string ToString()
        {
            return
                $"Commodity Trade: TicketNo: {TicketNo}, Account: {AccountName}, Symbol: {Symbol}, Side: {Side}, Shares {ExecShares}, OrderType: {OrderType}";
        }
    }
}
