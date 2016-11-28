// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Reject.cs" company="IntenseLab">
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
    ///     Message indicating that order can not be executed because of some reason.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class Reject : UserExecutionData
    {
        /// <summary>
        ///     Number of reject.
        /// </summary>
        public long RejectNo { get; set; }

        /// <summary>
        ///     Message that represents reason caused failure.
        /// </summary>
        public string RejectReason { get; set; }

        /// <summary>
        ///     Count of rejected shares.
        /// </summary>
        public int RejectShares { get; set; }

        /// <summary>
        ///     Abbreviation for stock name.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        ///     Number of transaction.
        /// </summary>
        public Guid TransactionNo { get; set; }

        /// <summary>
        ///     <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return
                $"Reject: TicketNo: {TicketNo}, Account: {AccountName}, Symbol: {Symbol}, RejectReason: {RejectReason}, RejectShares: {RejectShares}, RejectNo: {RejectNo}";
        }
    }
}