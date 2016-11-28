// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientTerminationType.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents type of client termination
    /// </summary>
    public enum ClientTerminationType
    {
        /// <summary>
        ///     Client must be terminated immediately.
        /// </summary>
        Immediately,

        /// <summary>
        ///     Client must be terminated when client's queue has processed termination message with curret type.
        /// </summary>
        DelayedCompletition
    }
}
