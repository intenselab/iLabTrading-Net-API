// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CancelReject.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Message that indicates about failed execution of <see cref="CancelOrder"/>.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class CancelReject : ExecutionCancelMessage
    {
        /// <summary>
        ///     Reason of cancel order failed execution.
        /// </summary>
        public string RejectReason { get; set; }

        /// <summary>
        ///     <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return $"CancelReject: TicketNo: {TicketNo}, CancelTicketNo: {CancelTicketNo}, Account: {AccountName}, RejectReason: {RejectReason}";
        }
    }
}