// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerHelper.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Messages;
using IntenseLab.Shared.Attributes;
using IntenseLab.Shared.Utils;
using IntenseLab.Shared.Utils.Commons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntenseLab.NetworkCommunication.Helpers
{
    /// <summary>
    ///     Represents helper functions for serialization.
    /// </summary>
    public static class SerializerHelper
    {
        private static readonly Dictionary<Type, uint> MessageTypesDictionary = new Dictionary<Type, uint>();
        private static bool IsInitialized { get; set; }

        /// <summary>
        ///     Initializes static members of the <see cref="NetworkHelper" /> class.
        /// </summary>
        public static void Initialize()
        {
            if(IsInitialized)
                return;
            if(!AssemblyHelper.IsInitialized)
                throw new InvalidOperationException($"{nameof(AssemblyHelper)} is not initialized");

            LoadPlatformPacketTypesFromAssembly();
            IsInitialized = true;
        }

        /// <summary>
        ///     Check if class is initialized before using.
        /// </summary>
        private static void CheckInitialization()
        {
            if (!IsInitialized)
                throw new InvalidOperationException($"{nameof(SerializerHelper)} is not initialized. Please call {nameof(Initialize)} method before using.");
        }

        /// <summary>
        ///     Load all exported types marked by <see cref="IntenseLabPacketAttribute"/> from assemblies marked by <see cref="IntenseLabAssemblyAttribute"/>
        /// </summary>
        private static void LoadPlatformPacketTypesFromAssembly()
        {
            var types = AssemblyHelper.GetExportedTypesByAttribute(typeof(IntenseLabPacketAttribute));
            foreach (var type in types)
            {
                MessageTypesDictionary.Add(type, Crc32Algorithm.Compute(type.Name));
            }
        }

        /// <summary>
        ///     Generate <see cref="PacketHeader"/> for specified message with specified length of serialized message and covert this header to array of bytes.
        /// </summary>
        /// <param name="packet">
        ///     Message derived from type <see cref="BaseMessage"/>
        /// </param>
        /// <param name="length">
        ///     The length of serialized message.
        /// </param>
        /// <returns>
        ///     Generated <see cref="PacketHeader"/> converted to array of bytes.
        ///  </returns>

        public static byte[] GenerateMessageHeader(BaseMessage packet,
            int length)
        {
            CheckInitialization();
            var header = new PacketHeader
            {
                MessageSize = (uint)length,
                MessageType = MessageTypesDictionary[packet.GetType()],
                Flags = 0
            };
            return NetworkHelper.StructureToByteArray(header);
        }



        /// <summary>
        ///     Convert specified CRC32 sum to type of message.
        /// </summary>
        /// <param name="type">
        ///     Calculated CRC32 sum..
        /// </param>
        /// <returns>
        ///     Type of message which responds to specified CRC32 sum.
        /// </returns>
        public static Type ConvertFromHashToPacketType(uint type)
        {
            CheckInitialization();
            return MessageTypesDictionary.FirstOrDefault(t => t.Value == type).Key;
        }
    }
}
