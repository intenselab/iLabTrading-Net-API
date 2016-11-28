using IntenseLab.NetworkCommunication.Helpers;
using System.Collections.Generic;

namespace IntenseLab.NetworkCommunication
{
    public class SocketSettings
    {
        /// <summary>
        ///     The network client keep alive interval.
        /// </summary>
        public int NetworkClientKeepAliveInterval { get; set; } = 1000;

        /// <summary>
        ///     The network client keep alive timeout.
        /// </summary>
        public int NetworkClientKeepAliveTimeout { get; set; } = 10000;

        /// <summary>
        ///     The network client receive buffer size.
        /// </summary>
        public int NetworkClientReceiveBufferSize { get; set; } = 1024 * 1024 * 3;

        /// <summary>
        ///     The network client receive timeout.
        /// </summary>
        public int NetworkClientReceiveTimeout { get; set; } = 24 * 60 * 60 * 1000; // timeout 1 day

        /// <summary>
        ///     The network client send buffer size.
        /// </summary>
        public int NetworkClientSendBufferSize { get; set; } = 1024 * 1024 * 3;

        /// <summary>
        ///     The network client send timeout.
        /// </summary>
        public int NetworkClientSendTimeout { get; set; } = 60 * 1000; //timeout 1 hour

        /// <summary>
        ///     The serializers list.
        /// </summary>
        public List<string> SerializersList { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether to use No Delay for socket.
        /// </summary>
        public bool UseNoDelay = false;

        /// <summary>
        ///     Initialize the <see cref="SocketSettings" /> class.
        /// </summary>
        public SocketSettings()
        {
            SerializersList = IntenseLabFrameworkInitializer.SerializerNameList;
        }
    }
}
