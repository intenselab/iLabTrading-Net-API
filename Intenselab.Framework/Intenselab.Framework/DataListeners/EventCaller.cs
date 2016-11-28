// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventCaller.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace IntenseLab.Framework
{
    /// <summary>
    ///     Represents container for <see cref="BaseDataListener"/>.
    /// </summary>
    public sealed class EventCaller
    {
        private readonly List<BaseDataListener> dataListeners = new List<BaseDataListener>(); 

        private void ProcessBaseMessage(BaseMessage data)
        {
            OnMessageSubject.OnNext(data);

            var listener = dataListeners.FirstOrDefault(t => t.CanProcessDataType(data.GetType()));

            if (listener != null)
                listener.ProcessData(data);
            else
                throw new Exception($"Received unsupported type from connection: {data.GetType().Name}");
        }

        /// <summary>
        ///     Process incoming exception.
        /// </summary>
        /// <param name="exception">
        ///     Exception for processing.
        /// </param>
        public void ProcessException(Exception exception)
        {
            OnExceptionSubject.OnNext(exception);
        }

        /// <summary>
        ///     Process incoming data.
        /// </summary>
        /// <param name="data">
        ///     Incoming data.
        /// </param>
        public void ProcessProviderPacket(DataPacket data)
        {
            if (data.Packet == null)
                return;

            try
            {
                ProcessBaseMessage(data.Packet);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        #region Events

        /// <summary>
        ///     Notify that any data derived from <see cref="BaseMessage"/> was processed.
        /// </summary>
        public IObservable<BaseMessage> OnMessage => OnMessageSubject.AsObservable();

        /// <summary>
        ///     Notify that exception was thrown.
        /// </summary>
        public IObservable<Exception> OnException => OnExceptionSubject.AsObservable();
        #endregion



        #region Event Callers

        /// <summary>
        ///     Activated when BaseMessage is coming
        /// </summary>
        private Subject<BaseMessage> OnMessageSubject { get; } = new Subject<BaseMessage>();

        /// <summary>
        ///     Activated when the exception is thrown.
        /// </summary>
        private Subject<Exception> OnExceptionSubject { get; } = new Subject<Exception>();

        #endregion

        #region Listeners Interacting

        /// <summary>
        ///     Try to add data listener to collection
        /// </summary>
        /// <param name="listener">
        ///     Data listener.
        /// </param>
        /// <returns>
        ///     Indicating whether listener was added.
        /// </returns>
        public bool TryAddDataListener(BaseDataListener listener)
        {
            if (dataListeners.Contains(listener))
                return false;

            dataListeners.Add(listener);
            return true;
        }

        /// <summary>
        ///     Try to remove data listener from collection.
        /// </summary>
        /// <param name="listener">
        ///     Data listener.
        /// </param>
        /// <returns>
        ///     Indicating whether listener was removed.
        /// </returns>
        public bool TryRemoveDataListener(BaseDataListener listener)
        {
            if (dataListeners.Contains(listener))
                return false;

            dataListeners.Remove(listener);
            return true;
        }

        #endregion
    }
}