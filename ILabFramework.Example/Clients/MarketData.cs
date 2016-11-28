using IntenseLab.Framework.Communication.Enums;
using IntenseLab.Framework.Communication.Messages;
using IntenseLab.Framework.Messages;
using System;

namespace ILabFramework.Example
{
    /// <summary>
    ///     Represents class that process markets data
    /// </summary>
    public class MarketData : BaseClient
    {
        private string Symbol { get; set; }

        public MarketData(User user) : 
            base(user)
        {}

        protected override void SubscribeSessionEvents()
        {
            Session.OnAuthorizationResponse += SessionOnAuthorizationResponse;
            Session.OnException += SessionOnException;

            Session.MarketDataClient.OnConnectionState += MarketDataClientOnOnConnectionState;

            Session.MarketDataClient.Events.OnLevel2 += EventsOnOnLevel2;
            Session.MarketDataClient.Events.OnPrint += EventsOnOnPrint;
            Session.MarketDataClient.Events.OnQuote += EventsOnOnQuote;
            Session.MarketDataClient.Events.OnTodayInfo += EventsOnOnTodayInfo;
        }

        protected override void UnsubscribeSessionEvents()
        {
            Session.OnAuthorizationResponse -= SessionOnAuthorizationResponse;
            Session.OnException -= SessionOnException;

            Session.MarketDataClient.OnConnectionState -= MarketDataClientOnOnConnectionState;

            Session.MarketDataClient.Events.OnLevel2 -= EventsOnOnLevel2;
            Session.MarketDataClient.Events.OnPrint -= EventsOnOnPrint;
            Session.MarketDataClient.Events.OnQuote -= EventsOnOnQuote;
            Session.MarketDataClient.Events.OnTodayInfo -= EventsOnOnTodayInfo;
        }

        public override void StartDemo()
        {
            Console.Clear();
            Logger.Instance.WriteLog("Market demo is started!!!",ConsoleColor.Cyan);
            base.StartDemo();
        }

        private void SessionOnException(object sender, Exception e)
        {
            Logger.Instance.WriteLog(e.Message,ConsoleColor.Red);
        }

        private void SessionOnAuthorizationResponse(object sender, AuthorizationSuccessResponse e)
        {
            Logger.Instance.WriteLog("Market on authorization response");
        }

        private void EventsOnOnTodayInfo(object sender, TodayInfo e)
        {
            Logger.Instance.WriteLog($"Today Info : {e}", ConsoleColor.Cyan);
        }

        private void EventsOnOnQuote(object sender, Quote e)
        {
            Logger.Instance.WriteLog($"Quote : {e}", ConsoleColor.Yellow);
        }

        private void EventsOnOnPrint(object sender, Print e)
        {
            Logger.Instance.WriteLog($"Print : {e}", ConsoleColor.DarkCyan);
        }

        private void EventsOnOnLevel2(object sender, Level2 e)
        {
            Logger.Instance.WriteLog($"Level2 : {e}", ConsoleColor.Green);
        }

        private void MarketDataClientOnOnConnectionState(object sender, bool isConnected)
        {
            Logger.Instance.WriteLog($"Market client is conneted = [{isConnected}]", ConsoleColor.DarkMagenta);

            if (!isConnected)
                return;

            Logger.Instance.WriteLog("Enter symbol you want to subscribe.");
            Symbol = Console.ReadLine()?.ToUpper();

            SubscribeOnSymbol();
        }

        /// <summary>
        ///     Subscribe on all data types for current symbol.
        /// </summary>
        private void SubscribeOnSymbol()
        {
            try
            {
                var request = CreateMarketDataRequest(SubscriptionAction.AddSubscription);
                Session.MarketDataClient.SendMarketDataRequest(request);
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog(ex.Message, ConsoleColor.Red);
            }
        }
       

        private MarketDataRequest CreateMarketDataRequest(SubscriptionAction action)
        {
            return new MarketDataRequest
            {
                DataType = MarketDataType.All,
                Symbol = Symbol,
                SubscriptionAction = action
            };
        }
    }
}