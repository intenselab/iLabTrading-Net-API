// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserAccountLinkInfo.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents link between user and it's accounts.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class UserAccountLinkInfo
    {
        /// <summary>
        ///     Create new instance of <see cref="UserAccountLinkInfo"/>.
        /// </summary>
        public UserAccountLinkInfo()
        {
            AccountNames = new List<string>();
        }
        
        /// <summary>
        ///     Gets or sets name if the user.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        ///     Gets or sets names of linked accounts.
        /// </summary>
        public List<string> AccountNames { get; set; }

        /// <summary>
        ///    <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return $"User:{User},\r\nAccounts:{string.Join("\r\n", AccountNames)}\r\n\r\n";
        }
    }
}