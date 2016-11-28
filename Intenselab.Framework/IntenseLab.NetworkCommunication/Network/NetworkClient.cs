// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NetworkClient.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using IntenseLab.Shared;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;

namespace IntenseLab.NetworkCommunication.Network
{
    /// <summary>
    ///     Provides extension for <see cref="TcpClient"/> with safe send/receive operations.
    /// </summary>
    public sealed class NetworkClient : TcpClient
    {
        /// <summary>
        ///     Last exceprion that occured during receive operation.
        /// </summary>
        public UcSocketException LastReceiverException { get; private set; }

        /// <summary>
        ///     Last exceprion that occured during send operation.
        /// </summary>
        public UcSocketException LastSenderException { get; private set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NetworkClient" /> class with specified <see cref="Socket"/>.
        /// </summary>
        /// <param name="newSocket">
        ///     Socket to perform network operations.
        /// </param>
        public NetworkClient(Socket newSocket)
        {
            Client = newSocket;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NetworkClient" /> class.
        /// </summary>
        public NetworkClient()
        {
            
        }

        /// <summary>
        ///     Connects the specified socket with timeout.
        /// </summary>
        /// <param name="host">
        ///     Host to connect.
        /// </param>
        /// <param name="port">
        ///     Port to connect.
        /// </param>
        /// <param name="timeout">
        ///     Period of time for waiting on success response.
        /// </param>
        /// <returns>
        ///     Result of connect operation.
        /// </returns>
        public bool Connect(string host, int port, TimeSpan timeout)
        {
            var result = BeginConnect(host, port, null, null);

            var success = result.AsyncWaitHandle.WaitOne(timeout, true);
            if (success)
            {
                EndConnect(result);
            }
            else
            {
                Close();
            }

            return success;
        }

        /// <summary>
        ///     Try to receive message of specified length from current socket and write it to specified <see cref="receivedBuffer"/>.
        ///     In case of failure, exception that occured will be saved in <see cref="LastReceiverException"/>
        /// </summary>
        /// <param name="length">
        ///     Size of message that should be received.
        /// </param>
        /// <param name="receivedBuffer">
        ///     Buffer for saving received message.
        /// </param>
        /// <returns>
        ///     Result of receive operation.
        /// </returns>
        public bool TryReceive(int length, out DataBuffer receivedBuffer)
        {
            var buffer = new DataBuffer();
            var tmpBuffer = new DataBuffer();

            try
            {
                int readMessageSize;
                try
                {
                    var networkStream = GetStream();
                    readMessageSize = networkStream.Read(tmpBuffer.GetBuffer(length), 0, length);
                    buffer.AddBuffer(tmpBuffer.GetBuffer(), readMessageSize);
                }
                catch (IOException ioException)
                {
                    return FaultedResult(
                        new UcSocketException(ioException),
                        out receivedBuffer);
                }
                catch (InvalidOperationException invalidOperationException)
                {
                    return FaultedResult(
                        new UcSocketException(invalidOperationException),
                        out receivedBuffer);
                }
                if (readMessageSize < 0)
                {
                    return FaultedResult(
                        new UcSocketException("Client closed connection"),
                        out receivedBuffer);
                }

                return SuccessResult(
                    buffer,
                    out receivedBuffer);
            }
            finally
            {
                buffer.FreeBuffer();
                tmpBuffer.FreeBuffer();
            }
        }

        /// <summary>
        ///     Try to receive message of specified length from current socket and write it to specified <see cref="receivedBuffer"/>.
        ///     This method should be used when size of message is greater than current socket maximum buffer size.
        ///     In case of failure, exception that occured will be saved in <see cref="LastReceiverException"/>
        /// </summary>
        /// <param name="messageLength">
        ///     Size of message that should be received.
        /// </param>
        /// <param name="receivedBuffer">
        ///     Buffer for saving received message.
        /// </param>
        /// <returns>
        ///     Result of receive operation.
        /// </returns>
        public bool TryReceiveCompletely(int messageLength, out DataBuffer receivedBuffer)
        {
            var currentPosition = 0;

            var buffer = new DataBuffer();
            var tmpBuffer = new DataBuffer();

            try
            {
                while (currentPosition != messageLength)
                {
                    int readMessageSize;
                    try
                    {
                        var remainingMessageLength = messageLength - currentPosition;
                        var bytesBuffer = tmpBuffer.GetBuffer(remainingMessageLength);
                        var networkStream = GetStream();
                        readMessageSize = networkStream.Read(bytesBuffer, 0, remainingMessageLength);
                    }
                    catch (IOException ioException)
                    {
                        return FaultedResult(
                            new UcSocketException(ioException),
                            out receivedBuffer);
                    }
                    catch (InvalidOperationException invalidOperationException)
                    {
                        return FaultedResult(
                            new UcSocketException(invalidOperationException),
                            out receivedBuffer);
                    }

                    if (readMessageSize < 1)
                    {
                        return FaultedResult(
                           new UcSocketException("Invalid messageLength of data packet or some data lost."),
                           out receivedBuffer);
                    }

                    buffer.AddBuffer(tmpBuffer.GetBuffer(), readMessageSize);
                    tmpBuffer.FreeBuffer();
                    currentPosition += readMessageSize;
                }

                Debug.Assert(currentPosition == messageLength);

                return SuccessResult(
                    buffer,
                    out receivedBuffer);
            }
            finally
            {
                buffer.FreeBuffer();
                tmpBuffer.FreeBuffer();
            }
        }

        private bool FaultedResult(UcSocketException exception, out DataBuffer result)
        {
            LastReceiverException = exception;
            result = null;
            return false;
        }

        private bool SuccessResult(DataBuffer receivedBuffer, out DataBuffer result)
        {
            LastReceiverException = null;
            result = new DataBuffer(receivedBuffer);
            return true;
        }

        /// <summary>
        ///     Try to send message asynchronously using <see cref="SocketAsyncEventArgs"/>
        ///          In case of failure, exception that occured will be saved in <see cref="LastSenderException"/>
        /// </summary>
        /// <param name="buffer">
        ///     Serialized message to send.
        /// </param>
        /// <returns>
        ///     Result of send operation.
        /// </returns>

        public bool TrySendAsync(byte[] buffer)
        {
            var asyncEventArgs = new SocketAsyncEventArgs();

            asyncEventArgs.SetBuffer(buffer, 0, buffer.Length);
            asyncEventArgs.Completed += (sender, args) => args.Dispose();


            if (Client.Connected)
            {
                Client.SendAsync(asyncEventArgs);
                return true;
            }


            Close();
            LastSenderException = new UcSocketException("Socket is disconnected.");
            return false;
        }

        /// <summary>
        ///     Set new socket to perform network operation.
        /// </summary>
        /// <param name="newSocket">
        ///     <see cref="Socket"/>
        /// </param>
        public void SetSocket(Socket newSocket)
        {
            Client = newSocket;
        }

        public bool IsDisposed { get; set; }
        protected override void Dispose(bool disposing)
        {
            IsDisposed = true;
            base.Dispose(disposing);
        }
    }
}
