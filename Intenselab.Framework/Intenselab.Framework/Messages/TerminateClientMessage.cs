// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TerminateClientMessage.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents message for terminating client.
    /// </summary>
    public class TerminateClientMessage : ClientTerminatedData
    {
        /// <summary>
        ///     Create new instance of <see cref="TerminateClientMessage"/> with specified type of termintation.
        /// </summary>
        /// <param name="clientTerminationType"></param>
        public TerminateClientMessage(ClientTerminationType clientTerminationType)
        {
            ClientTerminationType = clientTerminationType;
        }

        /// <summary>
        ///     Type of termination.
        /// </summary>
        public ClientTerminationType ClientTerminationType { get; }
    }
}
