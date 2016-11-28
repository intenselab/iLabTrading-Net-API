// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BsonPacketSerializer.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.ComponentModel.Composition;
using System.IO;

namespace IntenseLab.NetworkCommunication.Serializers
{
    /// <summary>
    ///     Represents packet serializer that uses BSON format.
    /// </summary>
    [Export]
    [IntenseLabPacketSerializer]
    public sealed class BsonPacketSerializer : IPacketSerializer
    {
        /// <summary>
        ///     <see cref="IPacketSerializer.DeserializePacket"/>
        /// </summary>
        public object DeserializePacket(byte[] buffer, Type type)
        {
            var ms = new MemoryStream(buffer);
            var serializer = new JsonSerializer();
            var reader = new BsonReader(ms, false, DateTimeKind.Unspecified);

            return serializer.Deserialize(reader, type);
        }

        /// <summary>
        ///     <see cref="IPacketSerializer.SerializePacket{T}"/>
        /// </summary>
        public byte[] SerializePacket<T>(T packet)
        {
            var ms = new MemoryStream();
            var serializer = new JsonSerializer();
            var writer = new BsonWriter(ms) {DateTimeKindHandling = DateTimeKind.Unspecified};

            serializer.Serialize(writer, packet);

            return ms.ToArray();
        }
    }
}