// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HandShake.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace IntenseLab.NetworkCommunication.Messages
{
    /// <summary>
    ///     Represents connection validation message that is send from server to client, when client connect.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class HandShake : BaseMessage
    {
        /// <summary>
        ///     Represents version of framework wich is used on server side.
        /// </summary>
        public string FrameworkVersion { get; set; }

        /// <summary>
        ///     Collection of available compressors.
        /// </summary>
        public List<string> PacketCompressors { get; set; }

        /// <summary>
        ///     Collection of available encryptors.
        /// </summary>
        public List<string> PacketEncryptors { get; set; }

        /// <summary>
        ///     Collection of available serializers.
        /// </summary>
        public List<string> PacketSerializers { get; set; }
    }
}