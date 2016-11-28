// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExecutionData.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Messages;
using System;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents base class with set of properties for all execution data.
    /// </summary>
    public abstract class ExecutionData : BaseMessage
    {
        /// <summary>
        ///     Gets or sets name of account.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        ///     Gets or sets time on market when message was created.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        ///     Gets or sets time of server when message was created.
        /// </summary>
        public DateTime ServerTime { get; set; }
    }
}
