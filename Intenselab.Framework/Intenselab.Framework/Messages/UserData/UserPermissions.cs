// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserPermissions.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents permissions for user.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class UserPermissions
    {
        /// <summary>
        ///     Value indicating whether user can create trading account.
        /// </summary>
        public bool CanCreateTraditionalAccount { get; set; }

        /// <summary>
        ///     Value indicating whether user can create admin account.
        /// </summary>
        public bool CanCreateAdminAccount { get; set; }

        /// <summary>
        ///     Value indicating whether user can change passwords of other users.
        /// </summary>
        public bool CanChangePassword { get; set; }


        /// <summary>
        ///     Value indicating whether user can update account information of other accounts.
        /// </summary>
        public bool CanUpdateAccountInfo { get; set; }

        /// <summary>
        ///     Value indicating whether user can update risk information of other accounts.
        /// </summary>
        public bool CanUpdateRiskInfo { get; set; }

        /// <summary>
        ///     Value indicating whether user can update user information of other users.
        /// </summary>
        public bool CanUpdateUserInfo { get; set; }

        /// <summary>
        ///     Value indicating whether user can update links between accounts and user.
        /// </summary>
        public bool CanUpdateUserAccountLinks { get; set; }

        /// <summary>
        ///     Can updates permissions of other managers.
        /// </summary>
        public bool CanUpdateManagerPermissions { get; set; }
    }
}
