// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Canceled.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Message that indicates about sucessfull execution of <see cref="CancelOrder"/>.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class Canceled : ExecutionCancelMessage
    {
        /// <summary>
        ///     Count of shares that were canceled.
        /// </summary>
        public int CanceledShares { get; set; }

        /// <summary>
        ///     Reason of cancellation.
        /// </summary>
        public string CancelReason { get; set; }

        /// <summary>
        ///     Match number of current cancelled.
        /// </summary>
        public long MatchNo { get; set; }

        /// <summary>
        ///     Count of shares that remain after current cancel operation.
        /// </summary>
        public int RemainShares { get; set; }

        /// <summary>
        ///     <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return $"Canceled: CancelTicketNo: {CancelTicketNo}, TicketNo: {TicketNo}, MatchNo: {MatchNo}, Account: {AccountName}, CancelReason: {CancelReason}";
        }
    }
}