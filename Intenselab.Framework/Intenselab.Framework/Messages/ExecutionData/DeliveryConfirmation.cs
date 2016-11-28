// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryConfirmation.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents notification about successfull <see cref="DeliveryOrder"/> execution.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class DeliveryConfirmation : ExecutionDeliveryMessage
    {
        /// <summary>
        ///     Name of correspond account.
        /// </summary>
        public string ReferenceAccountName { get; set; }
    }
}
