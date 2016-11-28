// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SymbolLimitation.cs" company="IntenseLab">
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
    ///     Represent count of symbols per user for specified type of market data.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class SymbolLimitation : BaseMessage
    {

        /// <summary>
        ///     Allowed count of symbol for subscribtion on Level1 data
        /// </summary>
        public uint Level1SymbolLimit { get; set; }

        /// <summary>
        ///     Allowed count of symbol for subscribtion on Level2 data
        /// </summary>
        public uint Level2SymbolLimit { get; set; }
    }
}
