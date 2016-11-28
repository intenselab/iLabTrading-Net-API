// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FailedAuthorizationReason.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{

    /// <summary>
    ///     Represents reason of authorization request failure.
    /// </summary>
    public enum FailedAuthorizationReason
    {
        /// <summary>
        ///     Login was incorrect.
        /// </summary>
        IncorrectUserName,

        /// <summary>
        ///     Password was incorrect.
        /// </summary>
        IncorrectPassword,

        /// <summary>
        ///     User is active now.
        /// </summary>
        UserIsAcive,

        /// <summary>
        ///     User is disabled now.
        /// </summary>
        UserIsDisabled,

        /// <summary>
        ///     Authorization server is not accessible now.
        /// </summary>
        AuthorizationServerIsNotAccessible
    }
}
