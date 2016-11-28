// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarketTime.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Messages;
using IntenseLab.Shared.Attributes;
using System;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Message that provides time of market at the moment.
    /// </summary>

    [Export]
    [IntenseLabPacket]
    public sealed class MarketTime : BaseMessage
    {
        /// <summary>
        ///     Time of the market at te moment.
        /// </summary>
        public DateTime Time { get; set; }
    }
}