// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseDataClient.cs" company="IntenseLab">
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

namespace IntenseLab.Framework
{

    /// <summary>
    ///      Represents base class for all data clients in API.
    /// </summary>
    public abstract class BaseDataClient
    {
        private const int DelayBeforeReconectMs = 3 * 1000;
        
        /// <summary>
        ///     Client with queues for communicating via network.
        /// </summary>
        protected TradingClientWithQueue Client { get; private set; }

        /// <summary>
        ///     Credentials of current user.
        /// </summary>
        protected UserCredentials CurrentUserCredentials { get; set; }
        private TradingChannel Channel { get; }
        private bool NeedToReconnect { get; set; }

        /// <summary>
        ///     Initialize <see cref="BaseDataClient"/> with specified channel.
        /// </summary>
        /// <param name="channel"></param>
        protected BaseDataClient(TradingChannel channel)
        {
            Channel = channel;
        }

        /// <summary>
        ///     Update user credentials for current data client.
        /// </summary>
        /// <param name="userCredentials"></param>
        public void ClientOnUpdateUserCredentials(UserCredentials userCredentials)
        {
            CurrentUserCredentials = userCredentials;
        }


        #region Base Client Events

        /// <summary>
        ///     Notify that exception was thrown during receive or send action.
        /// </summary>
        public IObservable<Exception> OnClientException => OnClientExceptionSubject.AsObservable();

        /// <summary>
        ///     Notify that any message was received.
        /// </summary>
        public IObservable<DataPacket> OnDataPacketReceived => OnDataPacketReceivedSubject.AsObservable();

        /// <summary>
        ///     Notify that client connection state was changed.
        /// </summary>
        public IObservable<ServerState> OnServerStateChanged => OnServerStateChangedSubject.AsObservable();

        /// <summary>
        ///     Notify that authorization was successfull for current client.
        /// </summary>
        public IObservable<AuthorizationSuccessResponse> OnAuthorizationSuccessResponse
            => OnAuthorizationSuccessResponseSubject.AsObservable();

        /// <summary>
        ///     Notify that authorization was failed for current client.
        /// </summary>
        public IObservable<AuthorizationFailedResponse> OnAuthorizationFailedResponse
            => OnAuthorizationFailedResponseSubject.AsObservable();



        /// <summary>
        ///     The on process exception.
        /// </summary>
        private Subject<Exception> OnClientExceptionSubject { get; } = new Subject<Exception>();

        /// <summary>
        ///     The on process provider packet.
        /// </summary>
        private Subject<DataPacket> OnDataPacketReceivedSubject { get; } = new Subject<DataPacket>();

        /// <summary>
        ///     Activated when server connectionstate changed
        /// </summary>
        private Subject<ServerState> OnServerStateChangedSubject { get; } = new Subject<ServerState>();

        private Subject<AuthorizationSuccessResponse> OnAuthorizationSuccessResponseSubject { get; } = new Subject<AuthorizationSuccessResponse>();

        private Subject<AuthorizationFailedResponse> OnAuthorizationFailedResponseSubject { get; } = new Subject<AuthorizationFailedResponse>();

        #endregion

        /// <summary>
        ///     Check if client client is initialized
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Throws when client was not initialized.
        /// </exception>
        protected void CheckClientIsInitilalized()
        {
            if (Client == null)
                throw new InvalidOperationException("Session is not connected.");
        }

        private void AuthorizeClient()
        {
            var authRequest = new AuthorizationRequest
            {
                UserCredentials = CurrentUserCredentials
            };
            Client.Send(authRequest);
        }

        private CancellationTokenSource clientAliveCancelationToken;


        /// <summary>
        ///     Connect current client to server with specified host and port.
        /// </summary>
        /// <param name="host">
        ///     Host of the server.
        /// </param>
        /// <param name="port">
        ///     Port of the server.
        /// </param>
        public void Connect(string host, int port)
        {
            NeedToReconnect = true;
            clientAliveCancelationToken = new CancellationTokenSource();
            Client = KeepConnectAlive(host, port);
        }

        /// <summary>
        ///     Disconnect current client from server.
        /// </summary>
        public void Disconect()
        {
            NeedToReconnect = false;
            clientAliveCancelationToken?.Cancel();
            Client?.Disconnect();
        }


        /// <summary>
        ///     Send message with checking whether session is connected.
        /// </summary>
        /// <param name="packet">
        ///     Message to send.
        /// </param>
        /// <typeparam name="T">
        ///     Any object derived from type <see cref="BaseMessage"/>
        /// </typeparam>
        protected void ClientSend<T>(T packet) where T : BaseMessage
        {
            CheckClientIsInitilalized();

            if (Client.Connected)
                Client.Send(packet);
        }



        /// <summary>
        ///     Keep connection alive until user will be connected
        /// </summary>
        /// <param name="host">
        ///     Host of the server.
        /// </param>
        /// <param name="port">
        ///     Port of the server.
        /// </param>
        /// <returns>
        ///     Connected client with queues.
        /// </returns>
        protected TradingClientWithQueue KeepConnectAlive(string host, int port)
        {
            var onReadyAction = new Action(() => OnServerStateChangedSubject.OnNext(ServerState.Connected));
            var onTerminatedAction = new Action(() => OnServerStateChangedSubject.OnNext(ServerState.Disconnected));

            if (Client == null)
            {
                Client = new TradingClientWithQueue(Channel);
                Client.OnDataPacketReceived.Subscribe(OnDataPacketReceivedSubject.OnNext);
                Client.OnClientTerminated.Subscribe(tuple =>
                {
                    onTerminatedAction();
                    Thread.Sleep(DelayBeforeReconectMs);
                    if(NeedToReconnect)
                        KeepConnectAlive(host, port);
                });

                Client.OnClientException.Subscribe(OnClientExceptionSubject.OnNext);
                Client.OnClientReady.Subscribe(isReady =>
                {
                    AuthorizeClient();
                    onReadyAction();
                });

                Client.Connect(host, port, false);
            }
            else
            {
                Client.Reconnect(host, port, false);
            }

            return Client;
        }

        internal void ProcessServerStateMessage(ServerState serverState)
        {
            OnServerStateChangedSubject.OnNext(serverState);
        }

        internal void ProcessAuthorizationSuccessResponse(AuthorizationSuccessResponse successResponse)
        {
            OnAuthorizationSuccessResponseSubject.OnNext(successResponse);
        }

        internal void ProcessAuthorizationFailedResponse(AuthorizationFailedResponse failedResponse)
        {
            OnAuthorizationFailedResponseSubject.OnNext(failedResponse);
        }


    }
}