// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserInfo.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents information about user.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class UserInfo : ClientData
    {
        /// <summary>
        ///     Create new instance of <see cref="UserInfo"/>
        /// </summary>
        public UserInfo()
        {
            UserCredentials = new UserCredentials();
            ConnectionSettings = new ConnectionSettings();
            UserPermissions = new UserPermissions();
            SymbolLimitation = new SymbolLimitation();
            DataAccess = new DataAccess();
            WindowAccess = new WindowAccess();
        }

        /// <summary>
        ///     <see cref="UserCredentials"/>.
        /// </summary>
        public UserCredentials UserCredentials { get; set; }

        /// <summary>
        ///     <see cref="ConnectionSettings"/>.
        /// </summary>
        public ConnectionSettings ConnectionSettings { get; set; }

        /// <summary>
        ///     <see cref="UserPermissions"/>.
        /// </summary>
        public UserPermissions UserPermissions { get; set; }

        /// <summary>
        ///     <see cref="SymbolLimitation"/>.
        /// </summary>
        public SymbolLimitation SymbolLimitation { get; set; }

        /// <summary>
        ///     <see cref="DataAccess"/>.
        /// </summary>
        public DataAccess DataAccess { get; set; }

        /// <summary>
        ///     <see cref="WindowAccess"/>.
        /// </summary>
        public WindowAccess WindowAccess { get; set; }

        /// <summary>
        ///     Value indicating whether user is enabled.
        /// </summary>
        public bool UserEnabled { get; set; }

        /// <summary>
        ///     Name of file that contains default layout.
        /// </summary>
        public string DefaultLayoutFileName { get; set; } = "demo.lay";

        /// <summary>
        ///     Value indicating whether user is administrator.
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        ///     Value indicating whether user is manager.
        /// </summary>
        public bool IsManager { get; set; }

        /// <summary>
        ///     Value indicating whether user is root.
        /// </summary>
        public bool IsRoot { get; set; }

    }
}
