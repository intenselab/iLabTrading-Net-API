// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntenseLabSession.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Framework.Messages;
using IntenseLab.NetworkCommunication.Helpers;
using IntenseLab.NetworkCommunication.Messages;
using IntenseLab.NetworkCommunication.Network;
using IntenseLab.Shared;
using IntenseLab.Shared.Attributes;
using IntenseLab.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reflection;

namespace IntenseLab.Framework
{
    /// <summary>
    ///     Session for connecting, authorizing and communicate with server side via network.
    /// </summary>
    public class IntenseLabSession : BaseDataListener
    {
        private ExecutionClient executionClient;
        private MarketDataClient marketDataClient;
        private HistoricalDataClient historicalDataClient;

        private bool IsInitialized { get; set; }

        /// <summary>
        ///     Create new instance of <see cref="IntenseLabSession"/> with default configured data listener.
        /// </summary>
        public IntenseLabSession()
        {
            Events = new EventCaller();
        }

        /// <summary>
        ///     Check if class is initialized before using.
        /// </summary>
        private void CheckInitialization()
        {
            if (!IsInitialized)
                throw new InvalidOperationException($"{nameof(IntenseLabSession)} is not initialized. Please call {nameof(Initialize)} method before using.");
        }

        /// <summary>
        ///     Initialize all dependencies according to specific platform.
        /// </summary>
        /// <param name="initializationType">
        ///     Type of initialization that represent specific platform.
        /// </param>
        public void Initialize(FrameworkInitializationType initializationType)
        {
            if(IsInitialized)
                return;

            switch (initializationType)
            {
                case FrameworkInitializationType.Desktop:
                    AssemblyHelper.Initialize(initializationType, null);
                    break;
                case FrameworkInitializationType.Mobile:
                    var mobileAssemblies = GetMobileAssemblies();
                    AssemblyHelper.Initialize(initializationType, mobileAssemblies);
                    break;
            }

            BaseInitialization();
        }

        /// <summary>
        ///     Initialize all dependencies according to specific platform.
        /// </summary>
        /// <param name="initializationType">
        ///     Type of initialization that represent specific platform.
        /// </param>
        /// <param name="additionalAssemblies">
        ///     Some additional assemblies, where messages marked by <see cref="IntenseLabPacketAttribute"/> may be found.
        /// </param>
        public void Initialize(FrameworkInitializationType initializationType, List<Assembly> additionalAssemblies)
        {
            if (IsInitialized)
                return;

            switch (initializationType)
            {
                case FrameworkInitializationType.Desktop:
                    AssemblyHelper.Initialize(initializationType, additionalAssemblies);
                    break;
                case FrameworkInitializationType.Mobile:
                    var mobileAssemblies = GetMobileAssemblies();
                    var assemblies = mobileAssemblies.Union(additionalAssemblies);
                    AssemblyHelper.Initialize(initializationType, assemblies);
                    break;
            }

            BaseInitialization();
        }

        private void BaseInitialization()
        {
            SerializerHelper.Initialize();
            IntenseLabFrameworkInitializer.Initialize();

            IsInitialized = true;

            Events.TryAddDataListener(this);
            SetupClients();
        }

        /// <summary>
        ///     Get base assemblies for mobile version without enumerating files in dirrectory.
        /// </summary>
        /// <returns>
        ///     Base collection of assemblies.
        /// </returns>
        private static IEnumerable<Assembly> GetMobileAssemblies()
        {
            var sharedAssembly = typeof(IntenseLabAssemblyAttribute).Assembly;
            var networkCommunicationAssembly = typeof(BaseMessage).Assembly;
            var frameworkAssembly = typeof(IntenseLabSession).Assembly;

            return new List<Assembly>
            {
                sharedAssembly,
                networkCommunicationAssembly,
                frameworkAssembly
            };
        }

        /// <summary>
        ///     Value indicating whether current user is authorized.
        /// </summary>
        protected bool IsAuthorized { get; set; }

        /// <summary>
        ///     Represents data listener.
        /// </summary>
        private EventCaller Events { get; }

        private TradingClientWithQueue AuthClient { get; set; }

        /// <summary>
        ///     Client for execution data.
        /// </summary>
        public ExecutionClient ExecutionClient
        {
            get
            {
                CheckInitialization();
                return executionClient;
            }
            private set { executionClient = value; }
        }

        /// <summary>
        ///     Client for historical data.
        /// </summary>
        public HistoricalDataClient HistoricalDataClient
        {
            get
            {
                CheckInitialization();
                return historicalDataClient;
            }
            private set { historicalDataClient = value; }
        }

        /// <summary>
        ///     Client for market data.
        /// </summary>
        public MarketDataClient MarketDataClient
        {
            get
            {
                CheckInitialization();
                return marketDataClient;
            }
            private set { marketDataClient = value; }
        }

        private DataAccess DataAccess { get; set; }

        /// <summary>
        ///     Connect all clients with specified connection settings.
        /// </summary>
        /// <param name="connectionSettings">
        ///     Connection settings.
        /// </param>
        protected virtual void ConnectClients(ConnectionSettings connectionSettings)
        {
            if (DataAccess == null)
                return;

            if (DataAccess.MarketDataAccessEnabled)
                MarketDataClient?.Connect(connectionSettings.MarketDataServerHost, connectionSettings.MarketDataServerPort);

            if (DataAccess.ExecutionDataAccessEnabled)
                ExecutionClient?.Connect(connectionSettings.ExecutionDataServerHost, connectionSettings.ExecutionDataServerPort);

            if (DataAccess.HistoricalDataAccessEnabled)
                HistoricalDataClient?.Connect(connectionSettings.HistoricalDataServerHost, connectionSettings.HistoricalDataServerPort);
        }

        /// <summary>
        ///     Setup all clients.
        /// </summary>
        private void SetupClients()
        {
            SetupClient(TradingChannel.MarketData);
            SetupClient(TradingChannel.ExecutionData);
            SetupClient(TradingChannel.HistoricalData);
        }

        /// <summary>
        ///     Disconnect all clients from connected servers.
        /// </summary>
        private void DisconnectClients()
        {
            MarketDataClient?.Disconect();
            ExecutionClient?.Disconect();
            HistoricalDataClient?.Disconect();
        }

        /// <summary>
        ///     Subscribe specified client on generalized events.
        /// </summary>
        /// <param name="client">
        ///     Client for subscribing.
        /// </param>
        private void ClientSubscribeEvents(BaseDataClient client)
        {
            OnUpdateAuthorizationInfo.Subscribe(client.ClientOnUpdateUserCredentials);

            client.OnClientException.Subscribe(Events.ProcessException);
            client.OnDataPacketReceived.Subscribe(Events.ProcessProviderPacket);
        }

        /// <summary>
        ///     Setting up client for specified trading channel.
        /// </summary>
        /// <param name="channel">
        ///     Trading channel of client.
        /// </param>
        private void SetupClient(TradingChannel channel)
        {
            BaseDataClient client;

            switch (channel)
            {
                case TradingChannel.MarketData:
                    {
                        var marketDataListener = new MarketDataListener();
                        Events.TryAddDataListener(marketDataListener);
                        MarketDataClient = new MarketDataClient(marketDataListener);
                        client = MarketDataClient;
                        break;
                    }
                case TradingChannel.ExecutionData:
                    {
                        var executionDataListener = new ExecutionDataListener();
                        var accountDataListener = new AccountDataListener();

                        Events.TryAddDataListener(executionDataListener);
                        Events.TryAddDataListener(accountDataListener);

                        ExecutionClient = new ExecutionClient(executionDataListener, accountDataListener);
                        client = ExecutionClient;
                        break;
                    }
                case TradingChannel.HistoricalData:
                    {
                        var historicalDataListener = new HistoricalDataListener();
                        Events.TryAddDataListener(historicalDataListener);

                        HistoricalDataClient = new HistoricalDataClient(historicalDataListener);
                        client = HistoricalDataClient;
                        break;
                    }
                default:
                    throw new ArgumentException("Unknown data client");
            }

            ClientSubscribeEvents(client);
        }

        /// <summary>
        ///     Try to connect and authorize to server with specified user credentials.
        /// </summary>
        /// <param name="userName">
        ///     Name of the user (It's login).
        /// </param>
        /// <param name="password">
        ///     Password of the user.
        /// </param>
        /// <param name="host">
        ///     Host of the authorization server.
        /// </param>
        /// <param name="port">
        ///     Port of the authorization server.
        /// </param>
        /// <returns>
        ///     Result of connecting to authorization server.
        /// </returns>
        public bool TryConnect(string userName, string password, string host, int port)
        {
            CheckInitialization();
            try
            {
                Disconnect();
                SubscribeBaseEvents();


                AuthClient = new TradingClientWithQueue(TradingChannel.Authorization);
                AuthClient.OnDataPacketReceived.Subscribe(Events.ProcessProviderPacket);
                AuthClient.OnClientReady.Subscribe(
                   client =>
                        AuthorizeClient(client, new UserCredentials
                        {
                            UserName = userName,
                            Password = password
                        }));
                AuthClient.Connect(host, port, true);
                return true;
            }
            catch (SocketException)
            {
                SendServerNotAccessibleResponse();
                return false;
            }
        }

        private void SendServerNotAccessibleResponse()
        {
            var failedResponse = new AuthorizationFailedResponse(FailedAuthorizationReason.AuthorizationServerIsNotAccessible, TradingChannel.Authorization);
            ProcessAuthorizationFailedResponse(failedResponse);
        }

        /// <summary>
        ///     Disconnect user from all servers.
        /// </summary>
        public void Disconnect()
        {
            CheckInitialization();
            UnsubscribeBaseEvents();
            DisconnectClients();
            IsAuthorized = false;
            DataAccess = null;
        }

        /// <summary>
        ///     Authorize client after it successfully connect to server.
        /// </summary>
        /// <param name="client">
        ///     Client for authorization
        /// </param>
        /// <param name="userCredentials">
        ///     Credentials of user.
        /// </param>
        protected virtual void AuthorizeClient(QueueTcpClient client, UserCredentials userCredentials)
        {
            var authRequest = new AuthorizationRequest
            {
                UserCredentials = userCredentials
            };
            client.EnqueueData(authRequest);
        }



        #region Data Listener Implementation

        /// <summary>
        ///     Fill map of supported generalized types and actions for session.
        /// </summary>
        protected override void FillActionsMap()
        {
            TypeAndAction = new Dictionary<Type, Action<object>>
            {
                {
                    typeof (AuthorizationSuccessResponse),
                    msg =>
                       ProcessAuthorizationSuccessResponse((AuthorizationSuccessResponse) msg)
                },
                {
                    typeof(AuthorizationFailedResponse),
                    msg => ProcessAuthorizationFailedResponse((AuthorizationFailedResponse)msg)
                },
                {
                    typeof (SystemNotification),
                    msg =>
                        ProcessSystemNotification((SystemNotification) msg)
                },
                {
                    typeof(RequestResult),
                    msg => OnRequestResultSubject.OnNext((RequestResult)msg)
                },
                {
                    typeof(ServerStateMessage),
                    msg => ProcessServerStateMessage((ServerStateMessage)msg)
                },
                {
                    typeof (ExecutorAccountConnectionStatus),
                    msg =>
                        OnExecutorAccountConnectionStatusSubject.OnNext(
                            (ExecutorAccountConnectionStatus) msg)
                }
            };
        }

        #endregion

        #region Events

        private IObservable<UserCredentials> OnUpdateAuthorizationInfo
        {
            get
            {
                CheckInitialization();
                return OnUpdateAuthorizationInfoSubject.AsObservable();
            }
        }


        /// <summary>
        ///     Notify that message of type <see cref="SystemNotification"/> was received.
        /// </summary>
        public IObservable<SystemNotification> OnSystemNotification
        {
            get
            {
                CheckInitialization();
                return OnSystemNotificationSubject.AsObservable();
            }
        }

        /// <summary>
        ///     Notify that authorization was successful.
        /// </summary>
        public IObservable<AuthorizationSuccessResponse> OnAuthorizationSuccessResponse
        {
            get
            {
                CheckInitialization();
                return OnAuthorizationSuccessResponseSubject.AsObservable();
            }
        }

        /// <summary>
        ///     Notify that authorization was failed.
        /// </summary>
        public IObservable<AuthorizationFailedResponse> OnAuthorizationFailedResponse
        {
            get
            {
                CheckInitialization();
                return OnAuthorizationFailedResponseSubject.AsObservable();
            }
        }

        /// <summary>
        ///     Notify that connection status of account was changed..
        /// </summary>
        public IObservable<RequestResult> OnRequestResult
        {
            get
            {
                CheckInitialization();
                return OnRequestResultSubject.AsObservable();
            }
        }

        /// <summary>
        ///     Notify that connection status of account was changed..
        /// </summary>
        public IObservable<ExecutorAccountConnectionStatus> OnExecutorAccountConnectionStatus
        {
            get
            {
                CheckInitialization();
                return OnExecutorAccountConnectionStatusSubject.AsObservable();
            }
        }

        /// <summary>
        ///     Notify thar exception was thrown.
        /// </summary>
        public IObservable<Exception> OnException
        {
            get
            {
                CheckInitialization();
                return OnExceptionSubject.AsObservable();
            }
        }

        /// <summary>
        ///     Notify that any data derived from <see cref="BaseMessage"/> was processed.
        /// </summary>
        public IObservable<BaseMessage> OnMessage
        {
            get
            {
                CheckInitialization();
                return OnMessageSubject.AsObservable();
            }
        }


        #endregion

        #region Event Subjects

        private Subject<Exception> OnExceptionSubject { get; } = new Subject<Exception>();
        private Subject<BaseMessage> OnMessageSubject { get; } = new Subject<BaseMessage>();
        private Subject<SystemNotification> OnSystemNotificationSubject { get; } = new Subject<SystemNotification>();
        private Subject<UserCredentials> OnUpdateAuthorizationInfoSubject { get; } = new Subject<UserCredentials>();
        private Subject<RequestResult> OnRequestResultSubject { get; } =
            new Subject<RequestResult>();
        private Subject<ExecutorAccountConnectionStatus> OnExecutorAccountConnectionStatusSubject { get; } =
            new Subject<ExecutorAccountConnectionStatus>();
        private Subject<AuthorizationSuccessResponse> OnAuthorizationSuccessResponseSubject { get; } =
            new Subject<AuthorizationSuccessResponse>();

        private Subject<AuthorizationFailedResponse> OnAuthorizationFailedResponseSubject { get; } =
           new Subject<AuthorizationFailedResponse>();

        #endregion

        #region Subscriptions

        private IDisposable EventsOnMessageSubscription { get; set; }
        private IDisposable EventsOnExceptionSubscription { get; set; }

        #endregion

        private void SubscribeBaseEvents()
        {
            EventsOnExceptionSubscription = Events.OnException.Subscribe(OnExceptionSubject.OnNext);
            EventsOnMessageSubscription = Events.OnMessage.Subscribe(OnMessageSubject.OnNext);
        }
        private void UnsubscribeBaseEvents()
        {
            EventsOnMessageSubscription?.Dispose();
            EventsOnExceptionSubscription?.Dispose();
        }



        #region System Notification Processing

        private void ProcessSystemNotification(SystemNotification systemNotification)
        {
            OnSystemNotificationSubject.OnNext(systemNotification);

            if (systemNotification.NotificationCode != NotificationCode.KickUser)
                return;

            Disconnect();
            SendSystemNotificationOnUnknownChannel(NotificationCode.UserWasKicked);
        }

        private void ProcessServerStateMessage(ServerStateMessage serverState)
        {
            var dataClient = GetClientByChannel(serverState.ServerChannel);
            dataClient?.ProcessServerStateMessage(serverState.State);
        }

        private void SendSystemNotificationOnUnknownChannel(NotificationCode notificationCode)
        {
            OnSystemNotificationSubject.OnNext(new SystemNotification
            {
                Channel = TradingChannel.ExecutionData,
                NotificationCode = notificationCode
            });
        }

        private void ProcessAuthorizationFailedResponse(AuthorizationFailedResponse authorizationFailedResponse)
        {
            if (authorizationFailedResponse.Channel == TradingChannel.Authorization)
            {
                OnAuthorizationFailedResponseSubject.OnNext(authorizationFailedResponse);
                return;
            }

            var dataclient = GetClientByChannel(authorizationFailedResponse.Channel);
            dataclient?.ProcessAuthorizationFailedResponse(authorizationFailedResponse);
        }

        private void ProcessAuthorizationSuccessResponse(AuthorizationSuccessResponse authorizationSuccessResponse)
        {
            if (authorizationSuccessResponse.Channel == TradingChannel.Authorization)
            {
                ProcessAuthorizationSuccessResponseOnAuthorizationChannel(authorizationSuccessResponse);
                return;
            }

            var dataclient = GetClientByChannel(authorizationSuccessResponse.Channel);
            dataclient?.ProcessAuthorizationSuccessResponse(authorizationSuccessResponse);
        }

        private void ProcessAuthorizationSuccessResponseOnAuthorizationChannel(
            AuthorizationSuccessResponse successResponse)
        {
            OnAuthorizationSuccessResponseSubject.OnNext(successResponse);

            if (!IsAuthorized)
            {
                IsAuthorized = true;
                DataAccess = successResponse.UserInfo.DataAccess;
                OnUpdateAuthorizationInfoSubject.OnNext(successResponse.UserInfo.UserCredentials);

                ConnectClients(successResponse.UserInfo.ConnectionSettings);
            }
            AuthClient.Disconnect();
        }

        private BaseDataClient GetClientByChannel(TradingChannel channel)
        {
            BaseDataClient dataClient = null;

            switch (channel)
            {
                case TradingChannel.MarketData:
                    dataClient = MarketDataClient;
                    break;
                case TradingChannel.ExecutionData:
                    dataClient = ExecutionClient;
                    break;
                case TradingChannel.HistoricalData:
                    dataClient = HistoricalDataClient;
                    break;
            }

            return dataClient;
        }

        #endregion
    }
}