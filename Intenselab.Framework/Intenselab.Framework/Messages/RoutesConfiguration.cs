// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoutesConfiguration.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents configuration for routes allowed for client.
    /// </summary>
    public class RoutesConfiguration
    {
        /// <summary>
        ///     Represents name of the routes that will be displayed for client when it's account option UseSmartRoute is enabled.
        /// </summary>
        public string SmartRouteName { get; set; }

        /// <summary>
        ///     Represents set of routes allowed for stocks that are not enumerated in <see cref="StocksSupportedRoutes"/>.
        /// </summary>
        public List<string> DefaultRoutes { get; set; }

        /// <summary>
        ///     Represents collection of routes onfiguration for special stocks.
        /// </summary>
        public List<StockSupportedRoutes> StocksSupportedRoutes { get; set; }
    }
}
