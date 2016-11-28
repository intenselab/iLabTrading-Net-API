// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseMessage.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace IntenseLab.NetworkCommunication.Messages
{
    /// <summary>
    ///     Represents custom exception for connection validation.
    /// </summary>
    public class InvalidClientException : Exception
    {
        /// <summary>
        ///     Represents type of client. 
        ///     <see cref="InvalidClientType"/>.
        /// </summary>
        public InvalidClientType ClientType { get; }

        /// <summary>
        ///     Create new instance of <see cref="InvalidClientException"/> with specified <see cref="clientType"/> and <see cref="message"/>.
        /// </summary>
        /// <param name="clientType">
        ///     Type of the client.
        /// </param>
        /// <param name="message">
        ///     Error message.
        /// </param>
        public InvalidClientException(InvalidClientType clientType, string message)
            : base(message)
        {
            ClientType = clientType;
        }
    }
}
