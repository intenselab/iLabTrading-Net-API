// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseTradingAction.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents actions, which could be made on CloseTrading request
    /// </summary>
    public enum CloseTradingAction
    {
        /// <summary>
        ///     Close all positions and cancel all pendings
        /// </summary>
        CloseAndCancelAll,
        /// <summary>
        ///     Cancel all pendings
        /// </summary>
        CancelPendings,
        /// <summary>
        ///     Close all positions
        /// </summary>
        ClosePositions
    }
}