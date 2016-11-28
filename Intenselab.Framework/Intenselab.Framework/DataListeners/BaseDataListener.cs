// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseDataListener.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace IntenseLab.Framework
{
    /// <summary>
    ///     Represents listener for data changing events.
    /// </summary>
    public abstract class BaseDataListener
    {
        /// <summary>
        ///     Message for unsupported types.
        /// </summary>
        private const string UnsupportedDataTypeMessage = "Received unsupported dataType from connection: {0}";

        /// <summary>
        ///     Gets or sets map of supported types and actions for current data listener.
        /// </summary>
        protected Dictionary<Type, Action<object>> TypeAndAction { get; set; } = new Dictionary<Type, Action<object>>();

        /// <summary>
        ///     Initialize properties of current class. 
        /// </summary>
        protected BaseDataListener()
        {
            FillActionsMap();
        }

        /// <summary>
        ///     Fill map of supported types and actions for current data listener.
        /// </summary>
        protected abstract void FillActionsMap();

        /// <summary>
        ///     Check whether listener can process data type.
        /// </summary>
        /// <param name="dataType">
        ///     Type of the message.
        /// </param>
        /// <returns>
        ///     Value indicating whether listener can process data type.
        /// </returns>
        public bool CanProcessDataType(Type dataType) => TypeAndAction.ContainsKey(dataType);


        /// <summary>
        ///     Try to process specified message.
        /// </summary>
        /// <param name="data">
        ///     Message for processing.
        /// </param>
        /// <exception cref="Exception">
        ///     Will be thrown when current listener does not support type of specified message.
        /// </exception>
        public void ProcessData(object data)
        {
            var dataType = data.GetType();
            if (!CanProcessDataType(dataType))
                throw new Exception(string.Format(UnsupportedDataTypeMessage, dataType.Name));

            var action = TypeAndAction[dataType];
            action(data);
        }
    }
}