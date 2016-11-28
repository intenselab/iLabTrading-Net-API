// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonPacketSerializer.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using Newtonsoft.Json;
using System;
using System.ComponentModel.Composition;
using System.Text;

namespace IntenseLab.NetworkCommunication.Serializers
{
    /// <summary>
    ///     Represents packet serializer that uses JSON format.
    /// </summary>
    [Export]
    [IntenseLabPacketSerializer]
    public sealed class JsonPacketSerializer : IPacketSerializer
    {
        /// <summary>
        ///     Represents settings for current serializer.
        /// </summary>
        private JsonSerializerSettings Settings { get; } = new JsonSerializerSettings();

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonPacketSerializer" /> class.
        /// </summary>
        public JsonPacketSerializer()
        {
            Settings.DateTimeZoneHandling = DateTimeZoneHandling.Unspecified;
        }

        /// <summary>
        ///     <see cref="IPacketSerializer.DeserializePacket"/>
        /// </summary>
        public object DeserializePacket(byte[] buffer, Type type)
        {
            return JsonConvert.DeserializeObject(Encoding.ASCII.GetString(buffer), type);
        }

        /// <summary>
        ///     <see cref="IPacketSerializer.SerializePacket{T}"/>
        /// </summary>
        public byte[] SerializePacket<T>(T packet)
        {
            var serializedPacket = JsonConvert.SerializeObject(packet, Formatting.None, Settings);
            return Encoding.ASCII.GetBytes(serializedPacket);
        }
    }
}