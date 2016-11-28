// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdminRequestType.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Type information that admin account need to receive.
    /// </summary>
    public enum AdminRequestType
    {
        /// <summary>
        ///     All account infoes.
        /// </summary>
        AllAccountInfoes,

        /// <summary>
        ///     All user infoes.
        /// </summary>
        AllUserInfoes,

        /// <summary>
        ///     All risk infoes.
        /// </summary>
        AllRiskInfoes,

        /// <summary>
        ///     All links between user and it's accounts.
        /// </summary>
        AllUserAccountLinks
    }
}