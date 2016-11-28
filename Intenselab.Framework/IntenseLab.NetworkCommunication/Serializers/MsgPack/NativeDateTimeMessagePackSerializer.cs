using MsgPack;
using MsgPack.Serialization;
using System;

namespace IntenseLab.NetworkCommunication.Serializers.MsgPack
{
    /// <summary>
    ///     Represents serializer for time without time's zone consideration.
    /// </summary>
    public sealed class NativeDateTimeMessagePackSerializer : MessagePackSerializer<DateTime>
    {
        /// <summary>
        ///     Initialize the <see cref="NativeDateTimeMessagePackSerializer"/>
        /// </summary>
        /// <param name="ownerContext">
        ///     The  <see cref="NativeDateTimeMessagePackSerializer"/> class.
        /// </param>
        public NativeDateTimeMessagePackSerializer(SerializationContext ownerContext)
            : base(ownerContext)
        {
        }

        /// <summary>
        ///     Serializes specified object with specified <see cref="T:MsgPack.Packer"/>.
        /// </summary>
        /// <param name="packer">
        ///     <see cref="T:MsgPack.Packer"/> which packs values in 
        ///     <paramref name="objectTree"/>.     This value will not be <c>null</c>.     </param>
        ///     <param name="objectTree">Object to be serialized.</param>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">
        ///     <typeparamref /> is not serializable etc.
        /// </exception>
        protected override void PackToCore(Packer packer, DateTime objectTree)
        {
            var myDt = DateTime.SpecifyKind(objectTree, DateTimeKind.Unspecified);
            packer.Pack(myDt.ToBinary());
        }

        /// <summary>
        ///     Deserializes object with specified <see cref="T:MsgPack.Unpacker"/>.
        /// </summary>
        /// <param name="unpacker">
        ///     <see cref="T:MsgPack.Unpacker"/> which unpacks values of resulting object tree. This value will not be <c>null</c>.
        /// </param>
        /// <returns>
        ///     Deserialized object.
        /// </returns>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">
        ///      Failed to deserialize object due to invalid unpacker state, stream content, or so.
        /// </exception>
        /// <exception cref="T:MsgPack.MessageTypeException">
        ///     Failed to deserialize object due to invalid unpacker state, stream content, or so.
        /// </exception>
        /// <exception cref="T:MsgPack.InvalidMessagePackStreamException">
        ///     Failed to deserialize object due to invalid unpacker state, stream content, or so.
        /// </exception>
        protected override DateTime UnpackFromCore(Unpacker unpacker)
        {
            return DateTime.FromBinary(unpacker.LastReadData.AsInt64());
        }
    }
}