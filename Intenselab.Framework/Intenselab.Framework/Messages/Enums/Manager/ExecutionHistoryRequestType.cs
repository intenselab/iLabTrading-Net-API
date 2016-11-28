// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExecutionHistoryRequestType.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Type of execution history of account that need to be received.
    /// </summary>
    public enum ExecutionHistoryRequestType
    {
        /// <summary>
        ///     All account activity.
        /// </summary>
        AllExecutionHistory,

        /// <summary>
        ///     Only active pendings, trades and positions.
        /// </summary>
        ActiveSession
    }
}