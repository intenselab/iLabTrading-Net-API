// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReceiveQueueDataWorker.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Framework.Messages;
using IntenseLab.NetworkCommunication.Messages;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace IntenseLab.Framework
{
    /// <summary>
    ///     Client that will represents receiving queue.
    /// </summary>
    public class ReceiveQueueDataWorker : QueueDataWorker
    {
        /// <summary>
        ///     <see cref="QueueDataWorker.ProcessDataPacket"/>
        /// </summary>
        protected override void ProcessDataPacket(DataPacket data)
        {
            OnDataPacketSubject.OnNext(data);

            switch (data.DataPacketType)
            {
                case DataPacketType.ClientData:
                    OnClientDataSubject.OnNext((ClientData)data.Packet);
                    break;
                case DataPacketType.MarketData:
                    OnMarketDataSubject.OnNext((MarketData)data.Packet);
                    break;
                case DataPacketType.ExecutionData:
                    OnExecutionDataSubject.OnNext((ExecutionData)data.Packet);
                    break;
                case DataPacketType.HistoricalData:
                    OnHistoricalDataSubject.OnNext((HistoricalData)data.Packet);
                    break;
                case DataPacketType.SystemData:
                    OnSystemDataSubject.OnNext(data.Packet);
                    break;
            }
        }

        #region events

        /// <summary>
        ///     Notify that any message was received.
        /// </summary>
        public IObservable<DataPacket> OnDataPacket => OnDataPacketSubject.AsObservable();

        /// <summary>
        ///     Notify that message of type <see cref="DataPacketType.SystemData"/> was received.
        /// </summary>
        public IObservable<BaseMessage> OnSystemData => OnSystemDataSubject.AsObservable();

        /// <summary>
        ///     Notify that message of type <see cref="DataPacketType.MarketData"/> was received.
        /// </summary>
        public IObservable<MarketData> OnMarketData => OnMarketDataSubject.AsObservable();

        /// <summary>
        ///     Notify that message of type <see cref="DataPacketType.ExecutionData"/> was received.
        /// </summary>
        public IObservable<ExecutionData> OnExecutionData => OnExecutionDataSubject.AsObservable();

        /// <summary>
        ///     Notify that message of type <see cref="DataPacketType.HistoricalData"/> was received.
        /// </summary>
        public IObservable<HistoricalData> OnHistoricalData => OnHistoricalDataSubject.AsObservable();

        /// <summary>
        ///     Notify that message of type <see cref="DataPacketType.ClientData"/> was received.
        /// </summary>
        public IObservable<ClientData> OnClientData => OnClientDataSubject.AsObservable();

        #endregion

        #region Subjects

        private Subject<DataPacket> OnDataPacketSubject { get; } = new Subject<DataPacket>();
        private Subject<BaseMessage> OnSystemDataSubject { get; } = new Subject<BaseMessage>();
        private Subject<MarketData> OnMarketDataSubject { get; } = new Subject<MarketData>();
        private Subject<ExecutionData> OnExecutionDataSubject { get; } = new Subject<ExecutionData>();
        private Subject<HistoricalData> OnHistoricalDataSubject { get; } = new Subject<HistoricalData>();
        private Subject<ClientData> OnClientDataSubject { get; } = new Subject<ClientData>();

        #endregion
    }
}
