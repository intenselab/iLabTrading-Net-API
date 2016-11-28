// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RiskInfo.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.Composition;
using IntenseLab.Shared.Attributes;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents risk settings for trading account
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class RiskInfo : ClientData
    {
        /// <summary>
        ///     Gets or sets the name of risk settings.
        /// </summary>
        public string RiskInfoName { get; set; }

        /// <summary>
        ///     Get or sets the value indicating whether to cancel all pendings for stock when position closes.
        /// </summary>
        public bool CancelPendingsOnPositionClose { get; set; }

        #region Dayly risks

        /// <summary>
        ///     Gets or sets maximum count of executed tickets per day.
        /// </summary>
        public int MaxTicketsPerDay { get; set; }
        /// <summary>
        ///     Gets or sets maximum count of executed shares per day.
        /// </summary>
        public int MaxSharesPerDay { get; set; }

        /// <summary>
        ///     Gets or sets maximum lost sum of money per day.
        /// </summary>
        public double MaxLossPerDay { get; set; }

        #endregion

        #region Monthly risks

        /// <summary>
        ///     Gets or sets maximum count of executed shares per month.
        /// </summary>
        public int MaxSharesPerMonth { get; set; }

        /// <summary>
        ///     Gets or sets maximum lost sum of money per month.
        /// </summary>
        public double MaxLossPerMonth { get; set; }

        #endregion

        #region Time Independent Risks

        /// <summary>
        ///     Gets or sets maximum count of shares per one ticket.
        /// </summary>
        public int MaxSharesPerTicket { get; set; }

        /// <summary>
        ///     Gets or sets maximum count of shares per position.
        /// </summary>
        public int MaxSharesPerPosition { get; set; }

        /// <summary>
        ///     Gets or sets maximum count of open shares. 
        /// </summary>
        public int MaxOpenShares { get; set; }

        #endregion

        #region Buying Power risks

        /// <summary>
        ///     Gets or sets maximum buying power.
        /// </summary>
        public double MaxBp { get; set; }

        /// <summary>
        ///     Gets or sets the max buying power per stock
        /// </summary>
        public double MaxBpPerStock { get; set; }

        /// <summary>
        ///     Get or sets the value indicating whether to use Buying Power Multiplier for account.
        /// </summary>
        public bool UseBpMultiplier { get; set; }

        /// <summary>
        ///     Get or sets the value for calculating <see cref="MaxBp"/> for account
        /// </summary>
        public double BpMultiplier { get; set; }

        #endregion

        #region Account Balance risks

        /// <summary>
        ///     Gets or sets sum for automatic closing account's positions if account's Open value will be lower.
        /// </summary>
        public double Autoclose { get; set; }
        /// <summary>
        ///     Gets or sets sum for automatic closing account's positions if account's Equity value will be lower.
        /// </summary>
        public double EquityAutoclose { get; set; }


        /// <summary>
        ///     Gets or sets maximum sum that account can earn.
        /// </summary>
        public double MaxTargetProfit { get; set; }


        #endregion

        #region Trading hours

        /// <summary>
        ///     Gets or sets a value indicating whether pre market is enabled.
        /// </summary>
        public bool PreMarketEnabled { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether post market is enabled.
        /// </summary>
        public bool PostMarketEnabled { get; set; }

        #endregion

        #region Stocks restriction

        /// <summary>
        ///     Gets or sets maximum stock price for trading.
        /// </summary>
        public double StockPriceRestriction { get; set; }

        /// <summary>
        ///     Gets or sets collection of stocks allowed for trading.
        /// </summary>
        public List<string> AllowedStocks { get; set; }

        /// <summary>
        ///     Gets or sets collection of stocks allowedrestricted for trading.
        /// </summary>
        public List<string> RestrictedStocks { get; set; }

        #endregion

        

        /// <summary>
        ///     <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return
                $"RiskInfoName: {RiskInfoName}, MaxTicketsPerDay: {MaxTicketsPerDay}, MaxSharesPerDay: {MaxSharesPerDay}, MaxLossPerDay: {MaxLossPerDay}, MaxSharesPerTicket: {MaxSharesPerTicket}, MaxSharesPerPosition: {MaxSharesPerPosition}, MaxSharesPerMonth: {MaxSharesPerMonth}, MaxLossPerMonth: {MaxLossPerMonth}, MaxBp: {MaxBp}, Autoclose: {Autoclose}, MaxTargetProfit: {MaxTargetProfit}, PreMarketEnabled: {PreMarketEnabled}, PostMarketEnabled: {PostMarketEnabled}, StockPriceRestriction: {StockPriceRestriction}, AllowedStocks: {AllowedStocks}, RestrictedStocks: {RestrictedStocks}, MaxOpenShares: {MaxOpenShares}, MaxBpPerStock: {MaxBpPerStock}";
        }
    }
}