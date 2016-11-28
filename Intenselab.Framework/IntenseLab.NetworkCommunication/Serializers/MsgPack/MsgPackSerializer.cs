// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MsgPackSerializers.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using IntenseLab.Shared.Utils;
using MsgPack.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;

namespace IntenseLab.NetworkCommunication.Serializers.MsgPack
{
    /// <summary>
    ///     Represents packet serializer that uses MsgPack format.
    /// </summary>
    [Export]
    [IntenseLabPacketSerializer]
    public sealed class MsgPackSerializer : IPacketSerializer
    {
        private static readonly Dictionary<Type, IMessagePackSerializer> Serializers =
            new Dictionary<Type, IMessagePackSerializer>();

        private static readonly SerializationContext Context = new SerializationContext();

        static MsgPackSerializer()
        {
            Context.Serializers.RegisterOverride(new NativeDateTimeMessagePackSerializer(Context));

            foreach (var type in AssemblyHelper.GetExportedTypesByAttribute(typeof (IntenseLabPacketAttribute)))
            {
                Serializers[type] = MessagePackSerializer.Get(type, Context);
            }
        }

        /// <summary>
        ///     <see cref="IPacketSerializer.DeserializePacket"/>
        /// </summary>
        public object DeserializePacket(byte[] buffer, Type type)
        {
            return Serializers[type].Unpack(new MemoryStream(buffer));
        }

        /// <summary>
        ///     <see cref="IPacketSerializer.SerializePacket{T}"/>
        /// </summary>
        public byte[] SerializePacket<T>(T packet)
        {
            var type = packet.GetType();
            if (!Serializers.ContainsKey(type))
                Serializers[type] = MessagePackSerializer.Get(type, Context);

            var stream = new MemoryStream();
            Serializers[packet.GetType()].Pack(stream, packet);

            return stream.ToArray();
        }
    }
}