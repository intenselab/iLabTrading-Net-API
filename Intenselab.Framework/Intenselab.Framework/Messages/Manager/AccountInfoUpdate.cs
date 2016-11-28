// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountInfoUpdate.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Messages;
using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{

    /// <summary>
    ///     Represents update for <see cref="AccountInfo"/>.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class AccountInfoUpdate : ClientData
    {
        /// <summary>
        ///     Type of update.
        /// </summary>
        public AccountInfoUpdateType AccountInfoUpdateType { get; private set; }

        /// <summary>
        ///     Account's information.
        /// </summary>
        public AccountInfo AccountInfo { get; private set; }


        /// <summary>
        ///     Create new instance of <see cref="AccountInfoUpdate"/>.
        /// </summary>
        public AccountInfoUpdate()
        {
            AccountInfoUpdateType = AccountInfoUpdateType.None;
            AccountInfo = null;
        }

        /// <summary>
        ///     Create new instance of <see cref="AccountInfoUpdate"/> with specified account information and type of update.
        /// </summary>
        /// <param name="accountInfo">
        ///     Account information
        /// </param>
        /// <param name="accountInfoUpdateType">
        ///     Type of update.
        /// </param>
        public AccountInfoUpdate(AccountInfo accountInfo, AccountInfoUpdateType accountInfoUpdateType)
        {
            AccountInfoUpdateType = accountInfoUpdateType;

            RiskInfo riskInfo = null;
            TradingStatistic tradingStatistic = null;

            if (accountInfoUpdateType.HasFlag(AccountInfoUpdateType.TradingStatistic))
                tradingStatistic = accountInfo.TradingStatistic?.ShallowCopy() as TradingStatistic;

            if (accountInfoUpdateType.HasFlag(AccountInfoUpdateType.RiskInfo))
                riskInfo = accountInfo.RiskInfo?.ShallowCopy() as RiskInfo;

            AccountInfo = (AccountInfo)accountInfo.ShallowCopy();
            AccountInfo.RiskInfo = riskInfo;
            AccountInfo.TradingStatistic = tradingStatistic;
        }

        /// <summary>
        ///     <see cref="BaseMessage.ShallowCopy"/>
        /// </summary>
        public override BaseMessage ShallowCopy()
        {
            var accountInfoUpdate = new AccountInfoUpdate
            {
                AccountInfo = AccountInfo,
                AccountInfoUpdateType = AccountInfoUpdateType
            };
            return accountInfoUpdate;
        }
    }
}
