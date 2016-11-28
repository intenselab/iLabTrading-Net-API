// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderError.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Message indicating that some fields in <see cref="NewOrder"/> are incorrect.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class OrderError : ExecutionData
    {
        /// <summary>
        ///     Get or set order id received in <see cref="NewOrder"/> client.
        /// </summary>
        public long ClientOrderId { get; set; }

        /// <summary>
        ///     Error message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return $"ClientOrderId: {ClientOrderId}, Text: {Message}";
        }
    }
}