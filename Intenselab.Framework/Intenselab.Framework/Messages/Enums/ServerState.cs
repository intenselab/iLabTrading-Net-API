// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerState.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents state of the connection to server.
    /// </summary>
    public enum ServerState
    {
        /// <summary>
        ///     Value indicate that client is not connected to server.
        /// </summary>
        Disconnected,

        /// <summary>
        ///     Value indicate that client is connect to server, but there are some problems.
        /// </summary>
        Problem,

        /// <summary>
        ///     Value indicate that client is connected to server.
        /// </summary>
        Connected,

        /// <summary>
        ///     Value indicate that client is connected to server and server is ready for interactions.
        /// </summary>
        Ready
    }
}
