// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StockSupportedRoutes.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents set of routes allowed for stock with specified name.
    /// </summary>
    public class StockSupportedRoutes
    {
        /// <summary>
        ///     Create new instance of <see cref="StockSupportedRoutes"/>
        /// </summary>
        public StockSupportedRoutes()
        {
            SupportedRoutes = new List<string>();
        }

        /// <summary>
        ///     Create new instance of <see cref="StockSupportedRoutes"/> with name of the stock and collection of allowed routes.
        /// </summary>
        public StockSupportedRoutes(string stockName, List<string>  supportedRoutes)
        {
            StockName = stockName;
            SupportedRoutes = supportedRoutes;
        }

        /// <summary>
        ///     Name of the stock.
        /// </summary>
        public string StockName { get; set; }

        /// <summary>
        ///     Collection of routes allowed for stock with specified name of the stock.
        /// </summary>
        public List<string> SupportedRoutes { get; set; } 
    }
}
