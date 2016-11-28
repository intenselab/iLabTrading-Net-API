// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseOrder.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     The base class for all orders.
    /// </summary>
    public abstract class BaseOrder : UserExecutionData
    {
        /// <summary>
        ///     Get or set order id for client.
        /// </summary>
        public long ClientOrderId { get; set; }
    }
}