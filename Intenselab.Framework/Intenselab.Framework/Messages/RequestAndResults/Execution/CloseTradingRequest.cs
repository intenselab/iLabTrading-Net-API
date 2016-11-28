// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseTradingRequest.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Request for close trading of specified account.
    /// </summary>
    public class CloseTradingRequest : ExecutionData
    {
        /// <summary>
        ///     Type of trading close. 
        /// </summary>
        public CloseTradingAction CloseTradingAction { get; set; }
    }
}