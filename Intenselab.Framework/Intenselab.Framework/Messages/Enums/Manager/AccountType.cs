// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountType.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Type of the account.
    /// </summary>
    public enum AccountType : byte
    {
        /// <summary>
        ///     Demo account.
        /// </summary>
        Demo,

        /// <summary>
        ///     Real aacount.
        /// </summary>
        Real,

        /// <summary>
        ///     Internal account.
        /// </summary>
        Internal
    }
}
