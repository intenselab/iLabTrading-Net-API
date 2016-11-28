// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseTcpServer.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Helpers;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;

namespace IntenseLab.NetworkCommunication.Network
{
    /// <summary>
    ///     Provides base functionality for TcpServer that can listen sockets and accept clients.
    /// </summary>
    public abstract class BaseTcpServer
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseTcpServer" /> class with specified settings of <see cref="Socket"/>.
        /// </summary>
        /// <param name="socketSettings">
        ///     Settings for <see cref="Socket"/>.
        /// </param>
        protected BaseTcpServer(SocketSettings socketSettings)
        {
            SocketSettings = socketSettings;
        }

        /// <summary>
        ///     Start listening specified <see cref="IPAddress"/> and <see cref="port"/>.
        /// </summary>
        /// <param name="host">
        ///     Host that will be listening.
        /// </param>
        /// <param name="port">
        ///     Port that will be listening.
        /// </param>
        public void Start(IPAddress host, int port)
        {
            if (Listener != null && Listener.Server.Connected)
                Stop();


            Port = port;
            Host = host;

            CancellationTokenSource = new CancellationTokenSource();
            WorkerTask = Task.Factory.StartNew(ThreadWorker, TaskCreationOptions.LongRunning);
        }

        /// <summary>
        ///     Worker function that will listen specified host and port and accept clients.
        /// </summary>
        private void ThreadWorker()
        {
            Listener = new TcpListener(Host, Port);
            Listener.Server.ReceiveTimeout = SocketSettings.NetworkClientReceiveTimeout;
            Listener.Start();

            var token = CancellationTokenSource.Token;
            while (!token.IsCancellationRequested)
            {
                var socket = Listener.AcceptSocket();
                SetupSocket(socket);
                AcceptClient(socket);
            }
        }

        /// <summary>
        ///     Configure specified <see cref="Socket"/>.
        /// </summary>
        /// <param name="socket">
        ///     Socket to configure.
        /// </param>
        private void SetupSocket(Socket socket)
        {
            socket.ReceiveTimeout = SocketSettings.NetworkClientReceiveTimeout;
            socket.SendTimeout = SocketSettings.NetworkClientSendTimeout;
            socket.ReceiveBufferSize = SocketSettings.NetworkClientReceiveBufferSize;
            socket.SendBufferSize = SocketSettings.NetworkClientSendBufferSize;
            socket.NoDelay = SocketSettings.UseNoDelay;

            NetworkHelper.SetKeepAliveValues(socket, true,
                keepAliveTime: (uint)SocketSettings.NetworkClientKeepAliveTimeout,
                keepAliveInterval: (uint)SocketSettings.NetworkClientKeepAliveInterval);
        }

        /// <summary>
        ///     Accpety client on specivied socket.
        /// </summary>
        /// <param name="socket">
        ///     Client's socket.
        /// </param>
        protected abstract void AcceptClient(Socket socket);

        /// <summary>
        ///     Accept client and add it to collection of connected clients.
        /// </summary>
        /// <param name="client">
        ///     Connected client.
        /// </param>
        protected void AcceptClient(BaseTcpClient client)
        {
            IDisposable subscription;

            ClientList.AddOrUpdate(client.NetworkClient, client, (networkClient, oldClient) =>
            {
                subscription = ClientSubscriptionList[oldClient.NetworkClient];
                subscription.Dispose();

                oldClient.StopReceive();
                return client;
            });

            subscription = client.OnTerminated.Subscribe(ClientOnTerminated);
            ClientSubscriptionList.AddOrUpdate(client.NetworkClient, subscription,
                (networkClient, oldSubscription) => subscription);
            client.StartReceive();

            OnClientConnectedSubject.OnNext(client);
        }

        /// <summary>
        ///     Action will be invoked when any exception occured in client during send or receive operation.
        /// </summary>
        /// <param name="eventArgs">
        ///     Represents <see cref="Tuple"/> of exception that cause failure and client which failed.
        /// </param>
        private void ClientOnTerminated(Tuple<BaseTcpClient,Exception> eventArgs)
        {
            var client = eventArgs.Item1;
            if (!ClientList.TryRemove(client.NetworkClient, out client))
                return;

            IDisposable subscription;
            ClientSubscriptionList.TryRemove(client.NetworkClient, out subscription);
            subscription?.Dispose();
                
            client.StopReceive();
        }

        /// <summary>
        ///     Stop to listen configured host and port.
        /// </summary>
        public void Stop()
        {
            Listener.Server.Close();
            CancellationTokenSource.Cancel();
            Task.WaitAll(WorkerTask);
        }

        #region Properties and fields

        /// <summary>
        ///     Configuration for socket.
        /// </summary>
        protected SocketSettings SocketSettings { get; }

        /// <summary>
        ///     Collection of connected clients.
        /// </summary>
        private ConcurrentDictionary<NetworkClient, BaseTcpClient> ClientList { get; } =
            new ConcurrentDictionary<NetworkClient, BaseTcpClient>();

        /// <summary>
        ///     List of subscriptions on client OnTerminatedEvent.
        /// </summary>
        private ConcurrentDictionary<NetworkClient, IDisposable> ClientSubscriptionList { get; } =
            new ConcurrentDictionary<NetworkClient, IDisposable>();

        /// <summary>
        ///     Host of current server.
        /// </summary>
        private IPAddress Host { get; set; }

        /// <summary>
        ///     <see cref="TcpListener"/>.
        /// </summary>
        private TcpListener Listener { get; set; }

        /// <summary>
        ///     Port of current server.
        /// </summary>
        private int Port { get; set; }

        /// <summary>
        ///     Worker task.
        /// </summary>
        private Task WorkerTask { get; set; }

        /// <summary>
        ///     Represents cancelation token source for thread worker.
        /// </summary>
        private CancellationTokenSource CancellationTokenSource { get; set; }

        /// <summary>
        ///     Will be activated after specified client connect to current server.
        /// </summary>
        protected IObservable<BaseTcpClient> OnClientConnected => OnClientConnectedSubject.AsObservable();

        private Subject<BaseTcpClient> OnClientConnectedSubject { get; } = new Subject<BaseTcpClient>(); 
       
        #endregion
        
    }
}