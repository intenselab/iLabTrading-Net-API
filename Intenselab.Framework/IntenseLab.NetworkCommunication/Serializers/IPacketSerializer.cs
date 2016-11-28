// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPacketSerializer.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace IntenseLab.NetworkCommunication.Serializers
{
    /// <summary>
    ///     Represents base interface for message serializers.
    /// </summary>
    public interface IPacketSerializer
    {
        /// <summary>
        ///     Deserialize message of specified type from <see cref="buffer"/>.
        /// </summary>
        /// <param name="buffer">
        ///     Serialized message.
        /// </param>
        /// <param name="type">
        ///     Type of object that need to be deserialized.
        /// </param>
        /// <returns>
        ///     Deserialized message of specified type.
        /// </returns>
        object DeserializePacket(byte[] buffer, Type type);

        /// <summary>
        ///     Serialize message of type <see cref="T"/> into array of bytes.
        /// </summary>
        /// <param name="packet">
        ///     Message that need to be serialized.
        /// </param>
        /// <typeparam name="T">
        ///     <see cref="T"/>
        /// </typeparam>
        /// <returns>
        ///     Serialized array of bytes.
        /// </returns>
        byte[] SerializePacket<T>(T packet);
    }
}