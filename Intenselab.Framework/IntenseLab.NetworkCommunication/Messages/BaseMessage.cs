// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseMessage.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared;

namespace IntenseLab.NetworkCommunication.Messages
{
    /// <summary>
    ///     Base class for every protocol messages.
    /// </summary>
    public abstract class BaseMessage
    {
        /// <summary>
        ///     Initialize field and properties from derived classes.
        /// </summary>
        protected BaseMessage()
        {
            Diag = new Diagnostics();
        }
        /// <summary>
        ///     <see cref="Diagnostics"/>.
        /// </summary>
        public Diagnostics Diag { get; set; }
        
        /// <summary>
        ///     Create a shallow copy of current object.
        /// </summary>
        /// <returns>
        ///     <see cref="BaseMessage" />.
        /// </returns>
        public virtual BaseMessage ShallowCopy()
        {
            return (BaseMessage)MemberwiseClone();
        }
    }
}
