// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExecutionDataListener.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Framework.Messages;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace IntenseLab.Framework
{
    /// <summary>
    ///     The listener for execution data.
    /// </summary>
    public sealed class ExecutionDataListener : BaseDataListener
    {
        /// <summary>
        ///     Fill map of supported types and actions for current <see cref="ExecutionDataListener"/>.
        /// </summary>
        protected override void FillActionsMap()
        {
            TypeAndAction = new Dictionary<Type, Action<object>>
            {
                {
                    typeof(SupportedRoutesResponse),
                    msg => OnSupportedRoutesResponseSubject.OnNext((SupportedRoutesResponse)msg)
                },
                {
                    typeof(CommodityPosition),
                    msg => OnCommodityPositionSubject.OnNext((CommodityPosition) msg)
                },
                {
                    typeof(CommodityTrade),
                    msg => OnCommodityTradeSubject.OnNext((CommodityTrade) msg)
                },
                {
                    typeof(DeliverySending),
                    msg => OnDeliverySendingSubject.OnNext((DeliverySending) msg)
                },
                {
                    typeof(DeliveryReject),
                    msg => OnDeliveryRejectSubject.OnNext((DeliveryReject) msg)
                },
                {
                    typeof(DeliveryConfirmation),
                    msg => OnDeliveryConfirmationSubject.OnNext((DeliveryConfirmation) msg)
                },
                {
                    typeof(Position),
                    msg => OnPositionUpdateSubject.OnNext((Position) msg)
                },
                {
                    typeof (Pending),
                    msg => OnPendingSubject.OnNext((Pending) msg)
                },
                {
                    typeof (Sending),
                    msg => OnSendingSubject.OnNext((Sending) msg)
                },
                {
                    typeof (Trade),
                    msg => OnTradeSubject.OnNext((Trade) msg)
                },
                {
                    typeof (Cancelling),
                    msg => OnCancellingSubject.OnNext((Cancelling) msg)
                },
                {
                    typeof (Canceled),
                    msg => OnCanceledSubject.OnNext((Canceled) msg)
                },
                {
                    typeof (Reject),
                    msg => OnRejectSubject.OnNext((Reject) msg)
                },
                {
                    typeof (CancelReject),
                    msg => OnCancelRejectSubject.OnNext((CancelReject) msg)
                },
                {
                    typeof (OrderError),
                    msg => OnOrderErrorSubject.OnNext((OrderError) msg)
                },
                {
                    typeof (Alert),
                    msg => OnAlertSubject.OnNext((Alert) msg)
                },
                {
                    typeof (ExecutionHistoryResponse),
                    msg => OnExecutionHistoryResponseSubject.OnNext((ExecutionHistoryResponse) msg)
                },
                {
                    typeof(PositionOpenUpdate),
                    msg=> OnPositionOpenUpdateSubject.OnNext((PositionOpenUpdate)msg)
                },
                {
                    typeof(CommodityPositionOpenUpdate),
                    msg=> OnCommodityPositionOpenUpdateSubject.OnNext((CommodityPositionOpenUpdate)msg)
                }
            };
        }

        #region Events

        /// <summary>
        ///     Activated when commodity position's open values are changed.
        /// </summary>
        public IObservable<CommodityPositionOpenUpdate> OnCommodityPositionOpenUpdate => OnCommodityPositionOpenUpdateSubject.AsObservable();

        /// <summary>
        ///     Activated when position's open values are changed.
        /// </summary>
        public IObservable<PositionOpenUpdate> OnPositionOpenUpdate=> OnPositionOpenUpdateSubject.AsObservable();
        /// <summary>
        ///     Notify that commodity position was updated.
        /// </summary>
        public IObservable<CommodityPosition> OnCommodityPosition => OnCommodityPositionSubject.AsObservable();

        /// <summary>
        ///     Notify that order on commodity route was executed fully or partialy.
        /// </summary>
        public IObservable<CommodityTrade> OnCommodityTrade => OnCommodityTradeSubject.AsObservable();

        /// <summary>
        ///     Notify that <see cref="DeliveryOrder"/> was successfully accepted on server side.
        /// </summary>
        public IObservable<DeliverySending> OnDeliverySending => OnDeliverySendingSubject.AsObservable();

        /// <summary>
        ///     Notify that <see cref="DeliveryOrder"/> has some incorrect fields or there is some other reason causing order's fail execution.
        /// </summary>
        public IObservable<DeliveryReject> OnDeliveryReject => OnDeliveryRejectSubject.AsObservable();

        /// <summary>
        ///     Notify that <see cref="DeliveryOrder"/> executes successfully.
        /// </summary>
        public IObservable<DeliveryConfirmation> OnDeliveryConfirmation => OnDeliveryConfirmationSubject.AsObservable();

        /// <summary>
        ///     Notify that repsponse on <see cref="SupportedRoutesRequest"/> was received.
        /// </summary>
        public IObservable<SupportedRoutesResponse> OnSupportedRoutesResponse => OnSupportedRoutesResponseSubject.AsObservable();

        /// <summary>
        ///     Notify that position was updated.
        /// </summary>
        public IObservable<Position> OnPositionUpdate => OnPositionUpdateSubject.AsObservable();

        /// <summary>
        ///     Notify that the order on the stock exchange waiting for execution.
        /// </summary>
        public IObservable<Pending> OnPending => OnPendingSubject.AsObservable();

        /// <summary>
        ///     Notify that order was successfully accepted on server side.
        /// </summary>
        public IObservable<Sending> OnSending => OnSendingSubject.AsObservable();

        /// <summary>
        ///     Notify that order was executed fully or partialy.
        /// </summary>
        public IObservable<Trade> OnTrade => OnTradeSubject.AsObservable();

        /// <summary>
        ///     Notify that cancel order was successfully accepted on server side.
        /// </summary>
        public IObservable<Cancelling> OnCancelling => OnCancellingSubject.AsObservable();

        /// <summary>
        ///     Notify that cancel order was successfully executed
        /// </summary>
        public IObservable<Canceled> OnCanceled => OnCanceledSubject.AsObservable();

        /// <summary>
        ///     Notify that order has some incorrect fields or there is some other reason causing order's fail execution.
        /// </summary>
        public IObservable<Reject> OnReject => OnRejectSubject.AsObservable();

        /// <summary>
        ///     Notify that there is some reason causing cancle order's fail execution.
        /// </summary>
        public IObservable<CancelReject> OnCancelReject => OnCancelRejectSubject.AsObservable();

        /// <summary>
        ///     Notify that order was not accepted on server side.
        /// </summary>
        public IObservable<OrderError> OnOrderError => OnOrderErrorSubject.AsObservable();

        /// <summary>
        ///    Notify about some special execution operation.
        /// </summary>
        public IObservable<Alert> OnAlert => OnAlertSubject.AsObservable();

        /// <summary>
        ///     Notify that repsponse on <see cref="ExecutionHistoryRequest"/> was received.
        /// </summary>
        public IObservable<ExecutionHistoryResponse> OnExecutionHistoryResponse => OnExecutionHistoryResponseSubject.AsObservable();
        #endregion

        #region Event Subjects


        /// <summary>
        ///     Activated when commodity position's open values are changed.
        /// </summary>
        private Subject<CommodityPositionOpenUpdate> OnCommodityPositionOpenUpdateSubject { get; } = new Subject<CommodityPositionOpenUpdate>();

        /// <summary>
        ///     Activated when position's open values are changed.
        /// </summary>
        private Subject<PositionOpenUpdate> OnPositionOpenUpdateSubject { get; } = new Subject<PositionOpenUpdate>();

        /// <summary>
        ///     Activated when repsponse on <see cref="SupportedRoutesRequest"/> was received.
        /// </summary>
        private Subject<SupportedRoutesResponse> OnSupportedRoutesResponseSubject { get; } = new Subject<SupportedRoutesResponse>();

        /// <summary>
        ///     Activated when commodity position was updated.
        /// </summary>
        private Subject<CommodityPosition> OnCommodityPositionSubject { get; } = new Subject<CommodityPosition>();

        /// <summary>
        ///     Activated when order on commodity route was executed fully or partialy.
        /// </summary>
        private Subject<CommodityTrade> OnCommodityTradeSubject { get; } = new Subject<CommodityTrade>();

        /// <summary>
        ///     Activated when <see cref="DeliveryOrder"/> was successfully accepted on server side.
        /// </summary>
        private Subject<DeliverySending> OnDeliverySendingSubject { get; } = new Subject<DeliverySending>();

        /// <summary>
        ///     Activated when <see cref="DeliveryOrder"/> has some incorrect fields or there is some other reason causing order's fail execution.
        /// </summary>
        private Subject<DeliveryReject> OnDeliveryRejectSubject { get; } = new Subject<DeliveryReject>();

        /// <summary>
        ///     Activated when <see cref="DeliveryOrder"/> executes successfully.
        /// </summary>
        private Subject<DeliveryConfirmation> OnDeliveryConfirmationSubject { get; } = new Subject<DeliveryConfirmation>();

        /// <summary>
        ///     Activated when position was updated.
        /// </summary>
        private Subject<Position> OnPositionUpdateSubject { get; } = new Subject<Position>();


        /// <summary>
        ///     Activated when the order on the stock exchange waiting for implementation
        /// </summary>
        private Subject<Pending> OnPendingSubject { get; } = new Subject<Pending>();

        /// <summary>
        ///     Activated when sending order to the stock exchange
        /// </summary>
        private Subject<Sending> OnSendingSubject { get; } = new Subject<Sending>();

        /// <summary>
        ///     Activated when trade is executed
        /// </summary>
        private Subject<Trade> OnTradeSubject { get; } = new Subject<Trade>();

        /// <summary>
        ///     activated when cancellation order, which was pending
        /// </summary>
        private Subject<Cancelling> OnCancellingSubject { get; } = new Subject<Cancelling>();

        /// <summary>
        ///     Activated when order is canceled
        /// </summary>
        private Subject<Canceled> OnCanceledSubject { get; } = new Subject<Canceled>();

        /// <summary>
        ///     Activated when rejecting order
        /// </summary>
        private Subject<Reject> OnRejectSubject { get; } = new Subject<Reject>();

        /// <summary>
        ///     Activated when reject is canceled by server
        /// </summary>
        private Subject<CancelReject> OnCancelRejectSubject { get; } = new Subject<CancelReject>();

        /// <summary>
        ///     Activated when order has invalid field values
        /// </summary>
        private Subject<OrderError> OnOrderErrorSubject { get; } = new Subject<OrderError>();

        /// <summary>
        ///     Activated when alert came from server
        /// </summary>
        private Subject<Alert> OnAlertSubject { get; } = new Subject<Alert>();

        /// <summary>
        ///     Activated when sending history data
        /// </summary>
        private Subject<ExecutionHistoryResponse> OnExecutionHistoryResponseSubject { get; } = new Subject<ExecutionHistoryResponse>();
        #endregion

    }
}