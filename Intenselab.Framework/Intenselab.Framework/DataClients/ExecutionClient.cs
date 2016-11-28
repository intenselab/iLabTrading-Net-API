// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExecutionClient.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Framework.Messages;

namespace IntenseLab.Framework
{

    /// <summary>
    ///     Represents client for execution data.
    /// </summary>
    public class ExecutionClient : BaseDataClient
    {

        /// <summary>
        ///     Listener for execution data.
        /// </summary>
        public readonly ExecutionDataListener ExecutionEvents;

        /// <summary>
        ///     Listener for account management data.
        /// </summary>
        public readonly AccountDataListener AccountEvents;

        /// <summary>
        ///     Initialize the <see cref="ExecutionClient"/> class.
        /// </summary>
        /// <param name="executionEvents">
        ///     Listener for execution data.
        /// </param>
        /// <param name="accountEvents">
        ///     Listener for account management data.
        /// </param>
        public ExecutionClient(ExecutionDataListener executionEvents,AccountDataListener accountEvents):
            base (TradingChannel.ExecutionData)
        {
            ExecutionEvents = executionEvents;
            AccountEvents = accountEvents;
        }


        #region Execution

        /// <summary>
        ///     Place order for current user.
        /// </summary>
        /// <param name="newOrder">
        ///     Order for placing.
        /// </param>
        public virtual void PlaceOrder(NewOrder newOrder)
        {
            newOrder.UserName = CurrentUserCredentials.UserName;
            ClientSend(newOrder);
        }

        /// <summary>
        ///     Place cancel order for current user.
        /// </summary>
        /// <param name="cancelOrder">
        ///     Cancel order for placing.
        /// </param>
        public virtual void CancelOrder(CancelOrder cancelOrder)
        {
            cancelOrder.UserName = CurrentUserCredentials.UserName;
            ClientSend(cancelOrder);
        }

        /// <summary>
        ///     Place delivery order for current user.
        /// </summary>
        /// <param name="deliveryOrder">
        ///     Delivery order for placing.
        /// </param>
        public void PlaceDeliveryOrder(DeliveryOrder deliveryOrder)
        {
            deliveryOrder.UserName = CurrentUserCredentials.UserName;
            ClientSend(deliveryOrder);
        }

        /// <summary>
        ///     Send request for execution history.
        /// </summary>
        /// <param name="request">
        ///     Request for execution history.
        /// </param>
        public void SendExecutionHistoryRequest(ExecutionHistoryRequest request)
        {
            ClientSend(request);
        }

        public void SendSupportedRoutesRequest(SupportedRoutesRequest request)
        {
            ClientSend(request);
        }

        #endregion

        #region Account Managament

        /// <summary>
        ///     Send request for creating new user.
        /// </summary>
        /// <param name="request">
        ///     User creation request.
        /// </param>
        public void CreateUser(UserCreationRequest request)
        {
            ClientSend(request);
        }

        /// <summary>
        ///     Send request for linked accounts.
        /// </summary>
        /// <param name="request">
        ///     Request for linked accounts.
        /// </param>
        public void SendLinkedAccountsRequest(LinkedAccountsRequest request)
        {
            ClientSend(request);
        }

        /// <summary>
        ///     Send request from admin user for information about accounts, users or links between them.
        /// </summary>
        /// <param name="request">Admin request</param>
        public void SendAdminRequest(AdminRequest request)
        {
            ClientSend(request);
        }

        /// <summary>
        ///     Send request for updating account's information.
        /// </summary>
        /// <param name="request">
        ///     Request for updating account's information.
        /// </param>
        public void SendAccountInfoUpdate(AccountInfoUpdateRequest request)
        {
            ClientSend(request);
        }

        /// <summary>
        ///     Send request for updating user's information.
        /// </summary>
        /// <param name="request">
        ///     Request for updating user's information.
        /// </param>
        public void SendUserInfoUpdate(UserInfoUpdateRequest request)
        {
            ClientSend(request);
        }

        /// <summary>
        ///     Send request for updating links between user and it's accounts.
        /// </summary>
        /// <param name="request">
        ///     Request for updating links between user and it's accounts.
        /// </param>
        public void SendUserAccountLinkUpdate(UserAccountLinkInfoUpdateRequest request)
        {
            ClientSend(request);
        }

        /// <summary>
        ///     Send request tto forcibly disconnect user from server.
        /// </summary>
        /// <param name="request">
        ///     Request for disconnecting user.
        /// </param>
        public void SendUserKickRequest(UserKickRequest request)
        {
            ClientSend(request);
        }

        #endregion
    }
}