using IntenseLab.Framework.Communication.Messages;
using IntenseLab.Framework.Messages;
using System;

namespace ILabFramework.Example
{
    /// <summary>
    ///     Represents class that process historical data
    /// </summary>
    public class HistoricalData : BaseClient
    {
        private string Symbol { get; set; }

        public HistoricalData(User user) : base(user)
        {}

        protected override void SubscribeSessionEvents()
        {
            Session.OnAuthorizationResponse += SessionOnAuthorizationResponse;
            Session.OnException += SessionOnException;

            Session.HistoricalDataClient.OnConnectionState += HistoricalDataClientOnConnectionState;

            Session.HistoricalDataClient.Events.OnHistoricalDataResponse += EventsOnHistoricalDataResponse;
        }

        protected override void UnsubscribeSessionEvents()
        {
            Session.OnAuthorizationResponse -= SessionOnAuthorizationResponse;
            Session.OnException -= SessionOnException;

            Session.HistoricalDataClient.OnConnectionState -= HistoricalDataClientOnConnectionState;

            Session.HistoricalDataClient.Events.OnHistoricalDataResponse -= EventsOnHistoricalDataResponse;
        }

        public override void StartDemo()
        {
            Console.Clear();
            Logger.Instance.WriteLog("Historical demo is started!!!", ConsoleColor.Cyan);
            base.StartDemo();
        }

        private void EventsOnHistoricalDataResponse(object sender, HistoricalDataResponse e)
        {
            if (e.ResponseCode == HistoricalResponseCode.OtherError)
            {
                Logger.Instance.WriteLog(e.Message);
                return;
            }

            if (e.HasBars)
            {
                Logger.Instance.WriteLog("Historical response BarList : ", ConsoleColor.DarkGreen);
                foreach (var bar in e.BarList)
                {
                    Logger.Instance.WriteLog($"Bar : {bar}", ConsoleColor.DarkGreen);
                }
            }

            if (e.HasTicks)
            {
                Logger.Instance.WriteLog("Historical response TickList : ", ConsoleColor.DarkBlue);
                foreach (var bar in e.TickList)
                {
                    Logger.Instance.WriteLog($"Tick : {bar}", ConsoleColor.Blue);
                }
            }
        }

        private void SessionOnException(object sender, Exception e)
        {
            Logger.Instance.WriteLog(e.Message, ConsoleColor.Red);
        }

        private void SessionOnAuthorizationResponse(object sender, AuthorizationSuccessResponse e)
        {
            Logger.Instance.WriteLog("Market on authorization response");
        }

        private void HistoricalDataClientOnConnectionState(object sender, bool isConnected)
        {
            Logger.Instance.WriteLog($"Historical client is conneted = [{isConnected}]", ConsoleColor.DarkMagenta);

            if (!isConnected)
                return;

            Logger.Instance.WriteLog("Enter symbol you want to get historical data.");
            Symbol = Console.ReadLine()?.ToUpper();


            SendHistoricalRequest(new HistoricalDataRequest
            {
                Symbol = Symbol,
                BeginDateTime = DateTime.Now.Date.AddDays(-1),
                EndDateTime = DateTime.Now.Date,
                BeginFilterTime = new TimeSpan(9, 30, 00),
                EndFilterTime = new TimeSpan(16, 00, 00),
                RequestType = HistoryRequestType.BarMin,
                RequestTypeParam = 5//five minute interval
            });
        }

        /// <summary>
        ///     Send request to server.
        /// </summary>
        /// <param name="request">
        ///     The <see cref="HistoricalDataRequest"/> object.
        /// </param>
        private void SendHistoricalRequest(HistoricalDataRequest request)
        {
            try
            {
                Session.HistoricalDataClient.SendHistoricalRequest(request);
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog(ex.Message, ConsoleColor.Red);
            }
        }
    }
}