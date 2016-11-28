// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequestResultType.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents type of result for request.
    /// </summary>
    public enum RequestResultType
    {
        /// <summary>
        ///     Value indicate that request status is "Failed".
        /// </summary>
        RequestFailed,

        /// <summary>
        ///     Value indicate that current account has no permission to execute such operation.
        /// </summary>
        AccessDeny,

        /// <summary>
        ///     Value indicate that current account is not enabled at the moment.
        /// </summary>
        UserIsDisabled,

        /// <summary>
        ///     Value indicate that specified user does not exist now.
        /// </summary>
        UserIsRemoved,

        /// <summary>
        ///     Value indicate that request status is "Success".
        /// </summary>
        RequestSuccess
    }
}
