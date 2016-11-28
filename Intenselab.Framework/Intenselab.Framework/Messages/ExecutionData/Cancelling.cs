// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cancelling.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{

    /// <summary>
    ///     Message indicating that server side accept <see cref="CancelOrder"/>.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class Cancelling : ExecutionCancelMessage
    {
        public Cancelling()
        {
            
        }
        /// <summary>
        ///     Get or set order id received in <see cref="CancelOrder"/> client.
        /// </summary>
        public long ClientOrderId { get; set; }

        /// <summary>
        ///     <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return $"Cancelling: Account: {AccountName}, ClientOrderId: {ClientOrderId}, TicketNo: {TicketNo}, CancelTicketNo: {CancelTicketNo}";
        }
    }
}