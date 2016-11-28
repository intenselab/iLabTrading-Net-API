// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TradingStatistic.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Messages;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents trading statistic for trading account.
    /// </summary>
    public class TradingStatistic : BaseMessage
    {
        /// <summary>
        ///     Gets or sets count of executed tickets at day.
        /// </summary>
        public int ExecutedTicketsAtDay { get; set; }

        /// <summary>
        ///     Gets or sets count of executed shares at day.
        /// </summary>
        public int ExecutedSharesAtDay { get; set; }


        /// <summary>
        ///     Value indicating possible income calculated by quotes.
        /// </summary>
        public double Open { get; set; }

        /// <summary>
        ///     Value indicating possible income calculated by print.
        /// </summary>
        public double OpenPrint { get; set; }

        /// <summary>
        ///     Value indicating already earned sum of money per current day.
        /// </summary>
        public double Close { get; set; }

        /// <summary>
        ///     Value indicating already earned sum of money per current month.
        /// </summary>
        public double MonthlyClose { get; set; }

        /// <summary>
        ///     Gets or sets used buying power at the moment.
        /// </summary>
        public double UsedBp { get; set; }

        /// <summary>
        ///     Gets or sets count of all shares per current day.
        /// </summary>
        public int SharesAtDay { get; set; }

        /// <summary>
        ///     Gets or sets count of open shares at the moment.
        /// </summary>
        public int OpenShares { get; set; }

        /// <summary>
        ///     Gets or sets count of accepted shares by server side.
        /// </summary>
        public int AcceptedSharesCount { get; set; }

        /// <summary>
        ///     Gets or sets value represents closed pend nuying power.
        /// </summary>
        public double ClosePendBp { get; set; }

        /// <summary>
        ///     Balance for previous day. (Account equity)
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        ///     Commissions charged for executed orders.
        /// </summary>
        public double Commissions { get; set; }
    }
}
