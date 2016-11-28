// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExecutionHistory.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Execution history of account.
    /// </summary>
    public class ExecutionHistory
    {
        /// <summary>
        ///     Collection of <see cref="Alert"/>
        /// </summary>
        public List<Alert> Alerts { get; set; } = new List<Alert>();

        /// <summary>
        ///     Collection of <see cref="Canceled"/>
        /// </summary>
        public List<Canceled> Canceleds { get; set; } = new List<Canceled>();

        /// <summary>
        ///     Collection of <see cref="Cancelling"/>
        /// </summary>
        public List<Cancelling> Cancellings { get; set; } = new List<Cancelling>();

        /// <summary>
        ///     Collection of <see cref="CancelOrder"/>
        /// </summary>
        public List<CancelOrder> CancelOrders { get; set; } = new List<CancelOrder>();

        /// <summary>
        ///     Collection of <see cref="CancelReject"/>
        /// </summary>
        public List<CancelReject> CancelRejects { get; set; } = new List<CancelReject>();

        /// <summary>
        ///     Collection of <see cref="OrderError"/>
        /// </summary>
        public List<OrderError> OrderErrors { get; set; } = new List<OrderError>();

        /// <summary>
        ///     Collection of <see cref="NewOrder"/>
        /// </summary>
        public List<NewOrder> Orders { get; set; } = new List<NewOrder>();

        /// <summary>
        ///     Collection of <see cref="Pending"/>
        /// </summary>
        public List<Pending> Pendings { get; set; } = new List<Pending>();

        /// <summary>
        ///     Collection of <see cref="Reject"/>
        /// </summary>
        public List<Reject> Rejects { get; set; } = new List<Reject>();

        /// <summary>
        ///     Collection of <see cref="Sending"/>
        /// </summary>
        public List<Sending> Sendings { get; set; } = new List<Sending>();

        /// <summary>
        ///     Collection of <see cref="Trade"/>
        /// </summary>
        public List<Trade> Trades { get; set; } = new List<Trade>();

        /// <summary>
        ///     Collection of <see cref="Position"/>
        /// </summary>
        public List<Position> Positions { get; set; } = new List<Position>();

        /// <summary>
        ///     Collection of <see cref="CommodityPosition"/>
        /// </summary>
        public List<CommodityPosition> CommodityPositions { get; set; } = new List<CommodityPosition>();

        /// <summary>
        ///     Collection of <see cref="CommodityTrade"/>
        /// </summary>
        public List<CommodityTrade> CommodityTrades { get; set; } = new List<CommodityTrade>();

        /// <summary>
        ///     Collection of <see cref="DeliveryOrder"/>
        /// </summary>
        public List<DeliveryOrder> DeliveryOrders { get; set; } = new List<DeliveryOrder>();

        /// <summary>
        ///     Collection of <see cref="DeliverySending"/>
        /// </summary>
        public List<DeliverySending> DeliverySendings { get; set; } = new List<DeliverySending>();

        /// <summary>
        ///     Collection of <see cref="DeliveryReject"/>
        /// </summary>
        public List<DeliveryReject> DeliveryRejects { get; set; } = new List<DeliveryReject>();

        /// <summary>
        ///     Collection of <see cref="DeliveryConfirmation"/>
        /// </summary>
        public List<DeliveryConfirmation> DeliveryConfirmations { get; set; } = new List<DeliveryConfirmation>();
    }
}