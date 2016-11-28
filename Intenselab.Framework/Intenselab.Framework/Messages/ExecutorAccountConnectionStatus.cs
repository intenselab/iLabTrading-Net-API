// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExecutorAccountConnectionStatus.cs" company="IntenseLab">
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
    ///     Represents connection status of specified account at the moment.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class ExecutorAccountConnectionStatus : BaseMessage
    {
        /// <summary>
        ///     Name of the account.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether account is connected.
        /// </summary>
        public bool IsConnected { get; set; }

        /// <summary>
        ///    Initialize the <see cref="ExecutorAccountConnectionStatus"/> account.
        /// </summary>
        /// <param name="accountName">
        ///     Name of the account.
        /// </param>
        /// <param name="isConnected">  
        ///     Value indicating whether account is connected.
        /// </param>
        /// <returns>
        ///     Created status message.
        /// </returns>
        public static ExecutorAccountConnectionStatus CreateState(string accountName, bool isConnected)
        {
            return new ExecutorAccountConnectionStatus {AccountName = accountName, IsConnected = isConnected};
        }

        /// <summary>
        ///    <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return $"Account: {AccountName}, Is connected: {IsConnected}";
        }
    }
}