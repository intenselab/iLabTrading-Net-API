// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HistoricalData.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using IntenseLab.NetworkCommunication.Messages;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents base class with set of properties for all historical data.
    /// </summary>
    public abstract class HistoricalData : BaseMessage
    {
        /// <summary>
        ///     Gets or sets id or the request.
        /// </summary>
        public long RequestId { get; set; }
    }
}
