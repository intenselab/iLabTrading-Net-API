// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HandShakeResponse.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.NetworkCommunication.Messages
{
    /// <summary>
    ///     Represents connection validation message that is send client to  server, after <see cref="HandShake"/> received.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class HandShakeResponse : BaseMessage
    {
        /// <summary>
        ///     Represents version of framework wich is used on client side.
        /// </summary>
        public string FrameworkVersion { get; set; }

        /// <summary>
        ///     Selected compressor.
        /// </summary>
        public string PacketCompressor { get; set; }

        /// <summary>
        ///     Selected encryptor.
        /// </summary>
        public string PacketEncryptor { get; set; }

        /// <summary>
        ///     Selected serializer.
        /// </summary>
        public string PacketSerializer { get; set; }
    }
}