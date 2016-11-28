// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Alert.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents notification about some special execution operation.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class Alert : ExecutionData
    {
        /// <summary>
        ///     Message of notification.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///    <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return $"Alert: Message: {Message} Time: {Time}";
        }
    }
}