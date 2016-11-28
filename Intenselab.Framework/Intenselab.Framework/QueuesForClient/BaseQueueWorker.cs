// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueueDataWorker.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Framework.Messages;
using IntenseLab.NetworkCommunication.Messages;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks.Dataflow;

namespace IntenseLab.Framework
{
    /// <summary>
    ///     Base classes for client with queues.
    /// </summary>
    public abstract class QueueDataWorker : IDataClientWithQueue
    {
        private CancellationTokenSource CancellationTokenSource { get; set; } = new CancellationTokenSource();

        /// <summary>
        ///     Gets or sets data queue.
        /// </summary>
        private ActionBlock<DataPacket> DataQueue { get; set; }

        /// <summary>
        ///     Gets a value indicating count of items in queue.
        /// </summary>
        public int ItemsInQueue => DataQueue.InputCount;

        /// <summary>
        ///     <see cref="IDataClientWithQueue.EnqueueData(DataPacket)"/>
        /// </summary>
        public void EnqueueData(DataPacket data)
        {
            if (data.DataPacketType == DataPacketType.ClientTerminated)
            {
                var terminatedMessage = (TerminateClientMessage)data.Packet;
                if (terminatedMessage.ClientTerminationType == ClientTerminationType.Immediately)
                {
                    CompleteQueue(ClientTerminationType.Immediately);
                    return;
                }
            }
            DataQueue.Post(data);
        }

        /// <summary>
        ///     <see cref="IDataClientWithQueue.EnqueueData(BaseMessage)"/>
        /// </summary>
        public void EnqueueData(BaseMessage data)
        {
            EnqueueData(new DataPacket(data));
        }


        /// <summary>
        ///     Start processing message via queue.
        /// </summary>
        public void Start()
        {
            Abort();

            CancellationTokenSource = new CancellationTokenSource();
            DataQueue = new ActionBlock<DataPacket>(
                data => ProcessDataPacketSafely(data),
                new ExecutionDataflowBlockOptions
                {
                    CancellationToken = CancellationTokenSource.Token
                });
        }

        /// <summary>
        ///     Stop processing all messages after all received messages till current moment were processed.
        /// </summary>
        public void Stop()
        {
            EnqueueData(DataPacket.CreateClientTerminatedPacket(ClientTerminationType.DelayedCompletition));
        }

        /// <summary>
        ///     Stop processing all messages immediately without processing all messages that have been already in queue.
        /// </summary>
        public void Abort()
        {
            EnqueueData(DataPacket.CreateClientTerminatedPacket(ClientTerminationType.Immediately));
        }

        
        private void ProcessDataPacketSafely(DataPacket dataPacket)
        {
            if(CancellationTokenSource.Token.IsCancellationRequested)
                return;

            try
            {
                if (dataPacket.DataPacketType == DataPacketType.ClientTerminated)
                {
                    CompleteQueue(ClientTerminationType.DelayedCompletition);
                    return;
                }

                ProcessDataPacket(dataPacket);

            }
            catch (Exception exception)
            {
                OnExceptionSubject.OnNext(exception);
            }
        }

        private void CompleteQueue(ClientTerminationType clientTerminationType)
        {
            CancellationTokenSource?.Cancel();
            DataQueue?.Complete();

            switch (clientTerminationType)
            {
                case ClientTerminationType.DelayedCompletition:
                    OnClientTerminatedSubject.OnNext(EventArgs.Empty);
                    break;
                case ClientTerminationType.Immediately:
                    OnAbortedSubject.OnNext(EventArgs.Empty);
                    break;
            }
        }

        /// <summary>
        ///     Method for processing message received from queue.
        /// </summary>
        /// <param name="data">
        ///     Received message with it defined type of data.
        /// </param>
        protected abstract void ProcessDataPacket(DataPacket data);

        #region events

        /// <summary>
        ///     Notify about any exception occured during processing message.
        /// </summary>
        public IObservable<Exception> OnException => OnExceptionSubject.AsObservable();

        /// <summary>
        ///     Notify that current client was terminated with successfull processing of all messages in queue.
        /// </summary>
        public IObservable<EventArgs> OnClientTerminated => OnClientTerminatedSubject.AsObservable();

        /// <summary>
        ///     Notify that current client was forcibly stopped to processing messages.
        /// </summary>
        public IObservable<EventArgs> OnAborted => OnAbortedSubject.AsObservable();

        #endregion

        #region Subjects

        private Subject<Exception> OnExceptionSubject { get; } = new Subject<Exception>();
        private Subject<EventArgs> OnClientTerminatedSubject { get; } = new Subject<EventArgs>();
        private Subject<EventArgs> OnAbortedSubject { get; } = new Subject<EventArgs>();

        #endregion
    }
}
