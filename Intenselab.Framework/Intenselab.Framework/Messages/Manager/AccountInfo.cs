// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountInfo.cs" company="IntenseLab">
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
    ///     Represents information about account.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class AccountInfo : ClientData
    {
        /// <summary>
        ///     Gets or sets name of account.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        ///     Gets or sets type of account.
        /// </summary>
        public AccountType AccountType { get; set; }

        /// <summary>
        ///     Gets or sets name of account's risk settings.
        /// </summary>
        public string RiskInfoName { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether account is locked.
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether account is enabled.
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is overnights enabled.
        /// </summary>
        public bool IsOvernightsEnabled { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether account need to use smart route.
        /// </summary>
        public bool UseSmartRoute { get; set; }

        /// <summary>
        ///     Gets ot sets commission rate for account.
        /// </summary>
        public MarketCommission CommissionRate { get; set; }

        /// <summary>
        ///     Gets or sets values that represents trading statistic for current account.
        /// </summary>
        public TradingStatistic TradingStatistic { get; set; } = new TradingStatistic();

        /// <summary>
        ///     Gets or set risk settings for current account.
        /// </summary>
        public RiskInfo RiskInfo { get; set; } = new RiskInfo();

        /// <summary>
        ///     <see cref="BaseMessage.ShallowCopy"/>  
        /// </summary>
        public override BaseMessage ShallowCopy()
        {
            var riskInfo = RiskInfo?.ShallowCopy() as RiskInfo;
            var tradingStatistic = TradingStatistic?.ShallowCopy() as TradingStatistic;

            var accInfo = (AccountInfo) base.ShallowCopy();
            accInfo.RiskInfo = riskInfo;
            accInfo.TradingStatistic = tradingStatistic;
            return accInfo;
        }


        /// <summary>
        ///     <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return
                $@"AccInfo: Name={AccountName}    
BP Used/Max={TradingStatistic.UsedBp,4:F}/{RiskInfo.MaxBp,-4:F}   
Open/Close={TradingStatistic.Open,3:F}/{TradingStatistic.Close,-3:F}
MonthlyClose={TradingStatistic.MonthlyClose,-3:F}
Tickets/Shares/ExecShares={TradingStatistic.ExecutedTicketsAtDay,2:F}/{TradingStatistic.SharesAtDay,-4:F}/{TradingStatistic.ExecutedSharesAtDay,-4:F}
AcceptedShares={TradingStatistic.AcceptedSharesCount}
ClosePendBP={TradingStatistic.ClosePendBp:F}
Locked={IsLocked}";
        }
    }
}