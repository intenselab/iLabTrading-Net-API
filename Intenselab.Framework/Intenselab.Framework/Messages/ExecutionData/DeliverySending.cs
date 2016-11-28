﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliverySending.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents message indicating that <see cref="DeliveryOrder"/> was accepted on server side.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class DeliverySending : ExecutionDeliveryMessage
    {
        /// <summary>
        ///     Id of received order.
        /// </summary>
        public long ClientOrderId { get; set; }
    }
}
