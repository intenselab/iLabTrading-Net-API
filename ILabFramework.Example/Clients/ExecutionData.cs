using IntenseLab.Framework.Communication.Enums;
using IntenseLab.Framework.Communication.Messages;
using IntenseLab.Framework.Messages;
using System;

namespace ILabFramework.Example
{
    /// <summary>
    ///     Represents class that process execution data
    /// </summary>
    public class ExecutionData : BaseClient
    {
        private string Symbol { get; set; }

        public ExecutionData(User user) : base(user)
        {}

        protected override void UnsubscribeSessionEvents()
        {
            Session.OnAuthorizationResponse -= SessionOnAuthorizationResponse;
            Session.OnException -= SessionOnException;

            Session.ExecutionClient.OnConnectionState -= ExecutionClientOnConnectionState;

            Session.ExecutionClient.ExecutionEvents.OnPending -= ExecutionEventsOnPending;
            Session.ExecutionClient.ExecutionEvents.OnSending -= ExecutionEventsOnSending;
            Session.ExecutionClient.ExecutionEvents.OnReject -= ExecutionEventsOnReject;
            Session.ExecutionClient.ExecutionEvents.OnTrade -= ExecutionEventsOnTrade;
            Session.ExecutionClient.ExecutionEvents.OnOrderError -= ExecutionEventsOnOrderError;

            Session.MarketDataClient.Events.OnQuote -= MarketClientOnQuote;
        }
        

        protected override void SubscribeSessionEvents()
        {
            Session.OnAuthorizationResponse += SessionOnAuthorizationResponse;
            Session.OnException += SessionOnException;

            Session.ExecutionClient.OnConnectionState += ExecutionClientOnConnectionState;

            Session.ExecutionClient.ExecutionEvents.OnPending += ExecutionEventsOnPending;
            Session.ExecutionClient.ExecutionEvents.OnSending += ExecutionEventsOnSending;
            Session.ExecutionClient.ExecutionEvents.OnReject += ExecutionEventsOnReject;
            Session.ExecutionClient.ExecutionEvents.OnTrade += ExecutionEventsOnTrade;
            Session.ExecutionClient.ExecutionEvents.OnOrderError += ExecutionEventsOnOrderError;

            Session.MarketDataClient.Events.OnQuote += MarketClientOnQuote;
        }

        private QuoteUpdateReason firstQuoteReason;
        private int quotesCount;
        private bool orderWasResended;

        private void MarketClientOnQuote(object sender, Quote quote)
        {
            if (quotesCount++ == 0)
                firstQuoteReason = quote.UpdateReason;


            if (orderWasResended || quote.UpdateReason == firstQuoteReason)
                return;

            PlaceOrder(new NewOrder
            {
                Symbol = Symbol,
                OrderType = OrderType.Mkt,
                Account = User.Login,
                User = User.Login,
                Route = "ARCA",
                Method = "ARCA",
                Side = OrderSide.Buy,
                Shares = 100
            });

            Session.MarketDataClient.SendMarketDataRequest(new MarketDataRequest
            {
                Symbol = Symbol,
                DataType = MarketDataType.All,
                SubscriptionAction = SubscriptionAction.RemoveSubscription
            });

            orderWasResended = true;
        }

        public override void StartDemo()
        {
            Console.Clear();
            Logger.Instance.WriteLog("Execution demo is started!!!", ConsoleColor.Cyan);
            base.StartDemo();
        }

        private void ExecutionEventsOnOrderError(object sender, OrderError e)
        {
            Logger.Instance.WriteLog($"Order Error : {e}", ConsoleColor.DarkRed);
        }

        private void ExecutionEventsOnTrade(object sender, Trade e)
        {
            Logger.Instance.WriteLog($"Trade : {e}", ConsoleColor.DarkGreen);
        }

        private void ExecutionEventsOnReject(object sender, Reject e)
        {
            Logger.Instance.WriteLog($"Reject : {e}", ConsoleColor.DarkYellow);

            if (e.RejectReason == "No information about symbol")
            {
                Logger.Instance.WriteLog("Do you want to subscribe on data and resend order? (Y/N)");
                var answer = Console.ReadLine()?.ToUpper();
                if (!string.IsNullOrEmpty(answer) && answer == "Y")
                {
                    Session.MarketDataClient.SendMarketDataRequest(new MarketDataRequest
                    {
                        Symbol = Symbol,
                        DataType =  MarketDataType.All,
                        SubscriptionAction = SubscriptionAction.AddSubscription
                    });
                }
            }
        }

        private void ExecutionEventsOnSending(object sender, Sending e)
        {
            Logger.Instance.WriteLog($"Sending : {e}", ConsoleColor.Yellow);
        }

        private void ExecutionEventsOnPending(object sender, Pending e)
        {
            Logger.Instance.WriteLog($"Pending : {e}", ConsoleColor.Magenta);
        }

        private void ExecutionClientOnConnectionState(object sender, bool isConnected)
        {
            Logger.Instance.WriteLog($"Execution client is conneted = [{isConnected}]", ConsoleColor.DarkMagenta);

            if (!isConnected)
                return;

            Logger.Instance.WriteLog("Enter symbol you want to send order.");
            Symbol = Console.ReadLine()?.ToUpper();

            PlaceOrder(new NewOrder
            {
                Symbol = Symbol,
                OrderType = OrderType.Mkt,
                Account = User.Login,
                User = User.Login,
                Route = "ARCA",
                Method = "ARCA",
                Side = OrderSide.Buy,
                Shares = 100
            });
        }

        private void SessionOnException(object sender, Exception e)
        {
            Logger.Instance.WriteLog(e.Message, ConsoleColor.Red);
        }

        private void SessionOnAuthorizationResponse(object sender, AuthorizationSuccessResponse e)
        {
            Logger.Instance.WriteLog("Execution on authorization response");
        }

        /// <summary>
        ///     Place order on server.
        /// </summary>
        /// <param name="order">
        ///     The <see cref="NewOrder"/> object.
        /// </param>
        public void PlaceOrder(NewOrder order)
        {
            try
            {
                Session.ExecutionClient.PlaceOrder(order);
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog(ex.Message, ConsoleColor.Red);
            }
        }
    }
}