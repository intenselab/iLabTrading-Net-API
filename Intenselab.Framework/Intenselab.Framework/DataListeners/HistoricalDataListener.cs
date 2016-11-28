// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HistoricalDataListener.cs" company="IntenseLab">
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
    ///     The listener for historical data.
    /// </summary>
    public sealed class HistoricalDataListener : BaseDataListener
    {
        /// <summary>
        ///     Fill map of supported types and actions for current <see cref="HistoricalDataListener"/>.
        /// </summary>
        protected override void FillActionsMap()
        {
            TypeAndAction = new Dictionary<Type, Action<object>>
            {
                {
                    typeof (HistoricalDataResponse),
                    msg =>
                        OnHistoricalDataResponseSubject.OnNext((HistoricalDataResponse) msg)
                }
            };
        }

        #region Events

        /// <summary>
        ///     Notify that response on <see cref="HistoricalDataRequest"/> was received.
        /// </summary>
        public IObservable<HistoricalDataResponse> OnHistoricalDataResponse => OnHistoricalDataResponseSubject.AsObservable();

        #endregion


        #region Event Subjects

        private Subject<HistoricalDataResponse> OnHistoricalDataResponseSubject { get; } =
            new Subject<HistoricalDataResponse>();

        #endregion

    }
}
