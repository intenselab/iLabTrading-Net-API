// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataPacket.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Framework.Messages;
using IntenseLab.NetworkCommunication.Messages;

namespace IntenseLab.Framework
{
    /// <summary>
    ///     Represents wrapper for <see cref="BaseMessage"/> with already defined type of data.
    /// </summary>
    public class DataPacket
    {
        /// <summary>
        ///     Original message.
        /// </summary>
        public BaseMessage Packet { get; }

        /// <summary>
        ///     Defined type of data.
        /// </summary>
        public DataPacketType DataPacketType { get; }

        /// <summary>
        ///     Initialize <see cref="DataPacket"/> class from specified message.
        /// </summary>
        /// <param name="packet">
        ///     Message for wrapping.
        /// </param>
        public DataPacket(BaseMessage packet)
        {
            DataPacketType = GetDataTypeByMessage(packet);
            Packet = packet;
        }

        /// <summary>
        ///     Create message for terminating client with specified type of termination.
        /// </summary>
        /// <param name="terminationType">
        ///     Type of termination.
        /// </param>
        /// <returns>
        ///     Created termination message.
        /// </returns>
        public static DataPacket CreateClientTerminatedPacket(ClientTerminationType terminationType)
        {
            return new DataPacket(new TerminateClientMessage(terminationType));
        }

        private static DataPacketType GetDataTypeByMessage(BaseMessage data)
        {
            if (data is ClientData)
                return DataPacketType.ClientData;

            if (data is MarketData)
                return DataPacketType.MarketData;

            if(data is ExecutionData)
                return DataPacketType.ExecutionData;
            
            if(data is HistoricalData)
                return DataPacketType.HistoricalData;

            if(data is ClientTerminatedData)
                return DataPacketType.ClientTerminated;

            return DataPacketType.SystemData;
        }
    }
}
