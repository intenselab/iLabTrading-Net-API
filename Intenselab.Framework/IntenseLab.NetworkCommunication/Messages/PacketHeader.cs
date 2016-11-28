// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketHeader.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.InteropServices;

namespace IntenseLab.NetworkCommunication.Messages
{
    /// <summary>
    ///     Represents binary header for all message that are sending via network.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PacketHeader
    {
        /// <summary>
        ///     Represents CRC32 computed sum of message type's name.
        /// </summary>
        public uint MessageType { get; set; }

        /// <summary>
        ///     Size of the message in bytes.
        /// </summary>
        public uint MessageSize { get; set; }

        /// <summary>
        ///     NOT USED NOW.
        ///     Represents some additional information.
        /// </summary>
        public long Flags { get; set; }
    }
}