// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataPacketType.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents type of data.
    /// </summary>
    public enum DataPacketType
    {
        /// <summary>
        ///     Messages derived from <see cref="MarketData"/>
        /// </summary>
        MarketData,

        /// <summary>
        ///     Messages derived from <see cref="ExecutionData"/>
        /// </summary>
        ExecutionData,

        /// <summary>
        ///     Messages derived from <see cref="HistoricalData"/>
        /// </summary>
        HistoricalData,

        /// <summary>
        ///     Messages derived from <see cref="ClientData"/>
        /// </summary>
        ClientData,

        /// <summary>
        ///     Messages derived from <see cref="ClientTerminatedData"/>
        /// </summary>
        ClientTerminated,

        /// <summary>
        ///     Other data types derived from <see cref="IntenseLab.NetworkCommunication.Messages.BaseMessage"/>
        /// </summary>
        SystemData
    }
}
