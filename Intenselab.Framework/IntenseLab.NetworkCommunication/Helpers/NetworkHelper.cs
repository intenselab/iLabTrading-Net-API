// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NetworkHelper.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace IntenseLab.NetworkCommunication.Helpers
{
    /// <summary>
    ///     Represents helper functions for network classes.
    /// </summary>
    internal static class NetworkHelper
    {

        /// <summary>
        ///     Convert structure to array of bytes.
        /// </summary>
        /// <param name="obj">
        ///    Struct which must be converted to array of bytes.
        /// </param>
        /// <returns>
        ///     Array of bytes.
        /// </returns>
        public static byte[] StructureToByteArray<T>(T obj) where T : struct 
        {
            var len = Marshal.SizeOf(obj);
            var arr = new byte[len];
            var ptr = Marshal.AllocHGlobal(len);
            Marshal.StructureToPtr(obj, ptr, true);
            Marshal.Copy(ptr, arr, 0, len);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        /// <summary>
        ///     Set keep alive values to specified <see cref="Socket"/>.
        /// </summary>
        /// <param name="socket">
        ///     Socket that must be configured.
        /// </param>
        /// <param name="onOff">
        ///     Value determines if TCP keep-alive is enabled or disabled
        /// </param>
        /// <param name="keepAliveTime">
        ///     Value specifies the timeout, in milliseconds, with no activity until the first keep-alive packet is sent.
        /// </param>
        /// <param name="keepAliveInterval">
        ///     Value specifies the interval, in milliseconds, between when successive keep-alive packets are sent if no acknowledgement is received.
        /// </param>
        /// <returns>
        ///     The number of bytes in the optionOutValue parameter.
        /// </returns>
        public static int SetKeepAliveValues(Socket socket, bool onOff, uint keepAliveTime, uint keepAliveInterval)
        {
            var keepAliveValues = new TcpKeepAlive
            {
                OnOff = Convert.ToUInt32(onOff),
                KeepAliveTime = keepAliveTime,
                KeepAliveInterval = keepAliveInterval
            };

            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, Convert.ToInt32(true));
            return socket.IOControl(IOControlCode.KeepAliveValues, StructureToByteArray(keepAliveValues), null);
        }

        /// <summary>
        ///     Represents struct with keep-alive configuration for <see cref="Socket"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct TcpKeepAlive
        {
            /// <summary>
            ///      Value determines if TCP keep-alive is enabled or disabled.
            /// </summary>
            public uint OnOff { get; set; }

            /// <summary>
            ///     Value specifies the timeout, in milliseconds, with no activity until the first keep-alive packet is sent.
            /// </summary>
            public uint KeepAliveTime { get; set; }

            /// <summary>
            ///     Value specifies the interval, in milliseconds, between when successive keep-alive packets are sent if no acknowledgement is received.
            /// </summary>
            public uint KeepAliveInterval { get; set; }
        }
    }
}
