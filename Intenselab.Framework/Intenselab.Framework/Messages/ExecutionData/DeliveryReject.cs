// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryReject.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents message indicating that <see cref="DeliveryOrder"/> was rejected on server side.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class DeliveryReject : ExecutionDeliveryMessage
    {
        /// <summary>
        ///     Reason of reject.
        /// </summary>
        public string RejectReason { get; set; }
    }
}
