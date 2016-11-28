// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountDataListener.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Framework.Messages;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace IntenseLab.Framework
{
    /// <summary>
    ///     The listener for account data changing.
    /// </summary>
    public sealed class AccountDataListener : BaseDataListener
    {
        /// <summary>
        ///     Fill map of supported types and actions for current <see cref="AccountDataListener"/>.
        /// </summary>
        protected override void FillActionsMap()
        {
            TypeAndAction = new Dictionary<Type, Action<object>>
            {
                {
                    typeof (UserInfoesResponse),
                    msg => OnAllUserInfoesResponseSubject.OnNext((UserInfoesResponse) msg)
                },
                {
                    typeof (LinkedAccountsResponse),
                    msg =>
                        OnLinkedAccountsResponseSubject.OnNext((LinkedAccountsResponse) msg)
                },
                {
                    typeof(AccountInfoesResponse),
                    msg => OnAllAccountInfoesResponseSubject.OnNext((AccountInfoesResponse)msg)
                },
                {
                    typeof (RiskInfoesResponse),
                    msg => OnAllRiskInfoResponseSubject.OnNext((RiskInfoesResponse) msg)
                },
                {
                    typeof (UserAccountLinksResponse),
                    msg =>  OnAllAccountLinksResponseSubject.OnNext((UserAccountLinksResponse) msg)
                },
                {
                    typeof (AccountInfoUpdate),
                    msg => OnAccountInfoUpdateSubject.OnNext((AccountInfoUpdate) msg)
                },
                {
                    typeof (AccountOpenUpdate),
                    msg => OnAccountOpenUpdateSubject.OnNext((AccountOpenUpdate) msg)
                },
                {
                    typeof (UserInfo),
                    msg => OnUserInfoUpdateSubject.OnNext((UserInfo) msg)
                },
                {
                    typeof (UserAccountLinkInfo),
                    msg => OnUserAccountLinksUpdateSubject.OnNext((UserAccountLinkInfo) msg)
                }
            };
        }

        #region Events

        /// <summary>
        ///     Notify that user's information was udated.
        /// </summary>
        public IObservable<UserInfo> OnUserInfoUpdate => OnUserInfoUpdateSubject.AsObservable();


        /// <summary>
        ///     Notify that account's information was udated.
        /// </summary>
        public IObservable<AccountOpenUpdate> OnAccountOpenUpdate => OnAccountOpenUpdateSubject.AsObservable();
        /// <summary>
        ///     Notify that account's information was udated.
        /// </summary>
        public IObservable<AccountInfoUpdate> OnAccountInfoUpdate => OnAccountInfoUpdateSubject.AsObservable();

        /// <summary>
        ///     Notify that link between user and it's accounts where updated.
        /// </summary>
        public IObservable<UserAccountLinkInfo> OnUserAccountLinksUpdate => OnUserAccountLinksUpdateSubject.AsObservable();

        /// <summary>
        ///     Notify that response on <see cref="LinkedAccountsRequest"/> was received.
        /// </summary>
        public IObservable<LinkedAccountsResponse> OnLinkedAccountsResponse => OnLinkedAccountsResponseSubject.AsObservable();

        /// <summary>
        ///     Notify that response on <see cref="AdminRequest"/> with type of requested information equals to <see cref="AdminRequestType.AllAccountInfoes"/> was received.
        /// </summary>
        public IObservable<AccountInfoesResponse> OnAllAccountInfoesResponse => OnAllAccountInfoesResponseSubject.AsObservable();

        /// <summary>
        ///     Notify that response on <see cref="AdminRequest"/> with type of requested information equals to <see cref="AdminRequestType.AllRiskInfoes"/> was received.
        /// </summary>
        public IObservable<RiskInfoesResponse> OnAllRiskInfoesResponse => OnAllRiskInfoResponseSubject.AsObservable();

        /// <summary>
        ///     Notify that response on <see cref="AdminRequest"/> with type of requested information equals to <see cref="AdminRequestType.AllUserInfoes"/> was received.
        /// </summary>
        public IObservable<UserInfoesResponse> OnAllUserInfoesResponse => OnAllUserInfoesResponseSubject.AsObservable();

        /// <summary>
        ///     Notify that response on <see cref="AdminRequest"/> with type of requested information equals to <see cref="AdminRequestType.AllUserAccountLinks"/> was received.
        /// </summary>
        public IObservable<UserAccountLinksResponse> OnAllUserAccountLinksResponse => OnAllAccountLinksResponseSubject.AsObservable();

        #endregion

        #region Event Callers

        /// <summary>
        ///     Activated when request data type AllUserInfo (1 user)
        /// </summary>
        private Subject<UserInfo> OnUserInfoUpdateSubject { get; } = new Subject<UserInfo>();


        /// <summary>
        ///     Activated when request data type LinkedAccounts (1 account)
        /// </summary>
        private Subject<AccountOpenUpdate> OnAccountOpenUpdateSubject { get; } = new Subject<AccountOpenUpdate>();
        /// <summary>
        ///     Activated when request data type LinkedAccounts (1 account)
        /// </summary>
        private Subject<AccountInfoUpdate> OnAccountInfoUpdateSubject { get; } = new Subject<AccountInfoUpdate>();
        /// <summary>
        ///     The on account links.
        /// </summary>
        private Subject<UserAccountLinkInfo> OnUserAccountLinksUpdateSubject { get; } = new Subject<UserAccountLinkInfo>();

      

        /// <summary>
        ///     Activated when request data type LinkedAccounts (array accounts)
        /// </summary>
        private Subject<LinkedAccountsResponse> OnLinkedAccountsResponseSubject { get; } = new Subject<LinkedAccountsResponse>();

        /// <summary>
        ///     Activated when request data type AllUserInfo (array users)
        /// </summary>
        private Subject<UserInfoesResponse> OnAllUserInfoesResponseSubject { get; } = new Subject<UserInfoesResponse>();

        private Subject<AccountInfoesResponse> OnAllAccountInfoesResponseSubject { get; } = new Subject<AccountInfoesResponse>();

        /// <summary>
        ///     The on all risk info response.
        /// </summary>
        private Subject<RiskInfoesResponse> OnAllRiskInfoResponseSubject { get; } = new Subject<RiskInfoesResponse>();

        /// <summary>
        ///     The on all account links response.
        /// </summary>
        private Subject<UserAccountLinksResponse> OnAllAccountLinksResponseSubject { get; } = new Subject<UserAccountLinksResponse>();

        #endregion

    }
}