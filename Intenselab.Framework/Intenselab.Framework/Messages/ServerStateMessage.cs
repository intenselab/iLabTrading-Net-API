// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerState.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Messages;
using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents state of the server on specified channel.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class ServerStateMessage : BaseMessage
    {
        /// <summary>
        ///     Channel of the server.
        /// </summary>
        public TradingChannel ServerChannel { get; set; }

        /// <summary>
        ///     State of the server.
        /// </summary>
        public ServerState State { get; set; }
    }
}
