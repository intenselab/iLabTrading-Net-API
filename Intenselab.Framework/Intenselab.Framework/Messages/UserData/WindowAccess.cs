// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindowAccess.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Messages;
using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents access to windows on client side.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class WindowAccess : BaseMessage
    {
        #region Market Data Windows

        /// <summary>
        ///     Value indicating whether user has access to open Level2 window.
        /// </summary>
        public bool Level2WindowAccessEnabled { get; set; }

        /// <summary>
        ///     Value indicating whether user has access to open Level2 NY window.
        /// </summary>
        public bool Level2NyWindowAccessEnabled { get; set; }

        /// <summary>
        ///     Value indicating whether user has access to open TNS window.
        /// </summary>
        public bool TnsTraditionalWindowAccessEnabled { get; set; }

        /// <summary>
        ///     Value indicating whether user has access to open TNS Simple window.
        /// </summary>
        public bool TnsSimpleWindowAccessEnabled { get; set; }

        /// <summary>
        ///     Value indicating whether user has access to open TNS Plus window.
        /// </summary>
        public bool TnsPlusWindowAccessEnabled { get; set; }

        /// <summary>
        ///     Value indicating whether user has access to open Level1 window.
        /// </summary>
        public bool Level1WindowAccessEnabled { get; set; }

        /// <summary>
        ///     Value indicating whether user has access to open NYSE Imbalance window.
        /// </summary>
        public bool NyseImbalanceWindowAccessEnabled { get; set; }

        /// <summary>
        ///     Value indicating whether user has access to open Board View  window.
        /// </summary>
        public bool BoardViewWindowAccessEnabled { get; set; }

        /// <summary>
        ///     Value indicating whether user has access to open Chart window.
        /// </summary>
        public bool ChartWindowAccessEnabled { get; set; }

        /// <summary>
        ///     Value indicating whether user has access to open Order Entry window.
        /// </summary>
        public bool OrderEntryWindowAccessEnabled { get; set; }

        #endregion

        /// <summary>
        ///     Value indicating whether user has access to open Trading windows.
        /// </summary>
        public bool TradingWindowsAccessEnabled { get; set; }

        /// <summary>
        ///     Value indicating whether user has access to add any custom plugin.
        /// </summary>
        public bool PluginAccessEnabled { get; set; }
    }
}
