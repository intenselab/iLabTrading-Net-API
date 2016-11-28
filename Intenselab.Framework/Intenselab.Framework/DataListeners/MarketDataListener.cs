// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarketDataListener.cs" company="IntenseLab">
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
    ///     The listener for market data.
    /// </summary>
    public sealed class MarketDataListener : BaseDataListener
    {
        /// <summary>
        ///     Fill map of supported types and actions for current <see cref="MarketDataListener"/>.
        /// </summary>
        protected override void FillActionsMap()
        {
            TypeAndAction = new Dictionary<Type, Action<object>>
            {
                {
                    typeof (Level2),
                    msg => OnLevel2Subject.OnNext((Level2) msg)
                },
                {
                    typeof (Level2Cache),
                    msg => OnLevel2CacheSubject.OnNext((Level2Cache) msg)
                },
                {
                    typeof (Print),
                    msg => OnPrintSubject.OnNext((Print) msg)
                },
                {
                    typeof (Quote),
                    msg => OnQuoteSubject.OnNext((Quote) msg)
                },
                {
                    typeof (TodayInfo),
                    msg => OnTodayInfoSubject.OnNext((TodayInfo) msg)
                },
                {
                    typeof (MarketTime),
                    msg => OnMarketTimeSubject.OnNext((MarketTime) msg)
                },
            };
        }

        #region Events

        /// <summary>
        ///     Notify that print was received.
        /// </summary>
        public IObservable<Print> OnPrint => OnPrintSubject.AsObservable();

        /// <summary>
        ///     Notify that quote was received.
        /// </summary>
        public IObservable<Quote> OnQuote => OnQuoteSubject.AsObservable();

        /// <summary>
        ///     Notify that level2 record was received.
        /// </summary>
        public IObservable<Level2> OnLevel2 => OnLevel2Subject.AsObservable();

        /// <summary>
        ///     Notify that level2 cache was received.
        /// </summary>
        public IObservable<Level2Cache> OnLevel2Cache => OnLevel2CacheSubject.AsObservable();

        /// <summary>
        ///     Notify that today info was received.
        /// </summary>
        public IObservable<TodayInfo> OnTodayInfo => OnTodayInfoSubject.AsObservable();

        /// <summary>
        ///     Notify that market time message was received.
        /// </summary>
        public IObservable<MarketTime> OnMarketTime => OnMarketTimeSubject.AsObservable();

        #endregion

        #region Event Subjects
        /// <summary>
        ///     The on print event.
        /// </summary>
        private Subject<Print> OnPrintSubject { get; } = new Subject<Print>();

        /// <summary>
        ///     The on quote event.
        /// </summary>
        private Subject<Quote> OnQuoteSubject { get; } = new Subject<Quote>();

        /// <summary>
        ///     The on level2 event.
        /// </summary>
        private Subject<Level2> OnLevel2Subject { get; } = new Subject<Level2>();

        /// <summary>
        ///     The on level2 cache event.
        /// </summary>
        private Subject<Level2Cache> OnLevel2CacheSubject { get; } = new Subject<Level2Cache>();

        /// <summary>
        ///     The on today info event.
        /// </summary>
        private Subject<TodayInfo> OnTodayInfoSubject { get; } = new Subject<TodayInfo>();

        /// <summary>
        ///     The on market time event.
        /// </summary>
        private Subject<MarketTime> OnMarketTimeSubject { get; } = new Subject<MarketTime>();

        #endregion

    }
}