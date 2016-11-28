// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UptimeHelper.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace IntenseLab.Shared.Utils
{
    /// <summary>
    ///     Represents helper for monitoring time elapsed from first class invokation.
    /// </summary>
    public static class UptimeHelper
    {
        /// <summary>
        ///     Date and time when instance was invoked first..
        /// </summary>
        private static readonly DateTime StartedAt = DateTime.UtcNow;

        /// <summary>
        ///     Gets full uptime elapsed.
        /// </summary>
        public static string FullUptimeElapsed
        {
            get
            {
                var diff = DateTime.UtcNow - StartedAt;
                return diff.ToString(@"d\.hh\:mm\:ss");
            }
           
        }
    }
}