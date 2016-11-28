// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeInForce.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents period of time of order topicality before execution or cancelling.
    /// </summary>
    public enum TimeInForce : byte
    {
        /// <summary>
        ///     Order will be actual for a current day.
        /// </summary>
        Day,

        /// <summary>
        ///     Order will be actual until it will be cancelled or executed.
        /// </summary>
        Gtc
    }
}