// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataPacket.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Framework.Messages;
using IntenseLab.NetworkCommunication.Interfaces;
using IntenseLab.NetworkCommunication.Messages;
using IntenseLab.NetworkCommunication.Network;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace IntenseLab.Framework
{
    /// <summary>
    ///     Represents wrapper for network client with it's local queues.
    /// </summary>
    public sealed class TradingClientWithQueue
    {
        /// <summary>
        ///     Trading channel of current client.
        /// </summary>
        public TradingChannel Channel { get; }

        /// <summary>
        ///     Indicates whether client is connected.
        /// </summary>
        public bool Connected => Client.NetworkClient.Connected;
        private Client Client { get; set; }
        private ReceiveQueueDataWorker ReceiveQueue { get; set; } = new ReceiveQueueDataWorker();
        private ISenderQueueFactory SendQueueFactory { get; } = new SenderQueueFactory();


        /// <summary>
        ///     Create new instance of <see cref="TradingClientWithQueue"/> with specified trading channel.
        /// </summary>
        /// <param name="channel">
        ///     Trading channel for current client.
        /// </param>
        public TradingClientWithQueue(TradingChannel channel)
        {
            Channel = channel;
            RecreateClient();
        }


        #region Events

        /// <summary>
        ///     Notify that any packet was received.
        /// </summary>
        public IObservable<DataPacket> OnDataPacketReceived => OnDataPacketReceivedSubject.AsObservable();

        /// <summary>
        ///     Notify that exception was thrown.
        /// </summary>
        public IObservable<Exception> OnClientException => OnClientExceptionSubject.AsObservable();

        /// <summary>
        ///     Notify that current client was terminated by specified exception.
        /// </summary>
        public IObservable<Tuple<BaseTcpClient, Exception>> OnClientTerminated => OnClientTerminatedSubject.AsObservable();

        /// <summary>
        ///     Notify that client is ready.
        /// </summary>
        public IObservable<QueueTcpClient> OnClientReady => OnClientReadySubject.AsObservable();

        #endregion

        #region Event Subjects

        /// <summary>
        ///     Activated to process provider packet.
        /// </summary>
        private Subject<DataPacket> OnDataPacketReceivedSubject { get; } = new Subject<DataPacket>();

        /// <summary>
        ///     Activated when exception occured.
        /// </summary>
        private Subject<Exception> OnClientExceptionSubject { get; } = new Subject<Exception>();

        /// <summary>
        ///     Activated when client is terminated
        /// </summary>
        private Subject<Tuple<BaseTcpClient, Exception>> OnClientTerminatedSubject { get; } = new Subject<Tuple<BaseTcpClient, Exception>>();

        /// <summary>
        ///     Activated when client is ready
        /// </summary>
        private Subject<QueueTcpClient> OnClientReadySubject { get; } = new Subject<QueueTcpClient>();

        #endregion

        #region Subscriptions

        private IDisposable ClientOnReadySubscription { get; set; }
        private IDisposable ClientOnTerminatedSubscription { get; set; }
        private IDisposable ClientOnExceptionSubscription { get; set; }
        private IDisposable ReceiveQueueOnDataPacketSubscription { get; set; }

        #endregion

        /// <summary>
        ///     Send specified message via network.
        /// </summary>
        /// <typeparam name="T">
        ///     Object derived from <see cref="BaseMessage"/>.
        /// </typeparam>
        /// <param name="packet">Packet
        ///     Message for sending.
        /// </param>
        public void Send<T>(T packet) where T : BaseMessage
        {
            Client.EnqueueData(packet);
        }

        /// <summary>
        ///     Stop receiving and processing messages.
        /// </summary>
        private void Stop()
        {
            ReceiveQueue.Abort();
            Unsubscribe();
        }

        /// <summary>
        ///     Start receiving and processing messages.
        /// </summary>
        private void Start()
        {
            Subscribe();
            ReceiveQueue.Start();
        }

        private void RecreateClient()
        {
            ReceiveQueue = new ReceiveQueueDataWorker();
            Client = new Client(ReceiveQueue, SendQueueFactory);
        }


        /// <summary>
        ///     Reconnect current client to specified host and port.
        /// </summary>
        /// <param name="host">
        ///     Host of the server.
        /// </param>
        /// <param name="port">
        ///     Port of the server.
        /// </param>
        /// <param name="rethrowConnectException">
        ///     Value indicating whether to throw exception when can not connect to server.
        /// </param>
        public void Reconnect(string host, int port, bool rethrowConnectException)
        {
            Disconnect();
            Connect(host, port,rethrowConnectException);
        }

        /// <summary>
        ///     Connect current client to specified host and port.
        /// </summary>
        /// <param name="host">
        ///     Host of the server.
        /// </param>
        /// <param name="port">
        ///     Port of the server.
        /// </param>
        /// <param name="rethrowConnectException">
        ///     Value indicating whether to throw exception when can not connect to server.
        /// </param>
        public void Connect(string host, int port, bool rethrowConnectException)
        {
            RecreateClient();
            Start();
            Client.Connect(host, port, rethrowConnectException);
        }


        /// <summary>
        ///     Disconnect current client from connected server.
        /// </summary>
        public void Disconnect()
        {
            Stop();
            Client.Disconnect();
        }

        private void Subscribe()
        {
            ClientOnReadySubscription = Client.OnReady.Subscribe(OnClientReadySubject.OnNext);
            ClientOnTerminatedSubscription = Client.OnTerminated.Subscribe(OnClientTerminatedSubject.OnNext);
            ClientOnExceptionSubscription = Client.OnException.Subscribe(OnClientExceptionSubject.OnNext);

            ReceiveQueueOnDataPacketSubscription = ReceiveQueue.OnDataPacket.Subscribe(dataPacket =>
            {
                if (dataPacket.Packet is SystemNotification)
                    ProcessSystemNotification((SystemNotification)dataPacket.Packet);
                if (dataPacket.Packet is ServerStateMessage)
                    ProcessServerState((ServerStateMessage)dataPacket.Packet);
                OnDataPacketReceivedSubject.OnNext(dataPacket);
            });
        }

        private void ProcessSystemNotification(SystemNotification systemNotification)
        {
            systemNotification.Channel = Channel;
        }

        private void ProcessServerState(ServerStateMessage serverState)
        {
            serverState.ServerChannel = Channel;
        }

        private void Unsubscribe()
        {
            ClientOnReadySubscription?.Dispose();
            ClientOnTerminatedSubscription?.Dispose();
            ClientOnExceptionSubscription?.Dispose();

            ReceiveQueueOnDataPacketSubscription?.Dispose();
        }
    }
}
