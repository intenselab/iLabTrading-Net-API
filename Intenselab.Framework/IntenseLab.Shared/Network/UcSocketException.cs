// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UcSocketException.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace IntenseLab.Shared
{
    /// <summary>
    ///     Represents common socket exception for InstenseLab API.
    /// </summary>
    [Serializable]
    public class UcSocketException : Exception
    {
        /// <summary>
        ///     Represents code of exception.
        /// </summary>
        public int ExceptionCode { get; }


        /// <summary>
        ///     Initializes a new instance of the <see cref="UcSocketException" /> class.
        /// </summary>
        public UcSocketException()
        {
        }


        /// <summary>
        ///     Initializes a new instance of the <see cref="UcSocketException" /> class.
        /// </summary>
        /// <param name="info">
        ///     <see cref="SerializationInfo" />
        /// </param>
        /// <param name="context">
        ///      <see cref="StreamingContext" />
        /// </param>
        protected UcSocketException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="UcSocketException" /> class.
        ///     Set code of exception.
        /// </summary>
        /// <param name="message">
        ///     Error message.
        /// </param>
        /// <param name="code">
        ///     Code of exception.
        /// </param>
        public UcSocketException(string message, int code)
            : base(message)
        {
            ExceptionCode = code;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="UcSocketException" /> class.
        /// </summary>
        /// <param name="message">
        ///     Error message.
        /// </param>
        public UcSocketException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="UcSocketException" /> class.
        /// </summary>
        /// <param name="inner">
        ///     Inner exception.
        /// </param>
        public UcSocketException(Exception inner)
            : base(string.Empty, inner)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="UcSocketException" /> class.
        /// </summary>
        /// <param name="message">
        ///     Error message.
        /// </param>
        /// <param name="inner">
        ///     Inner exception.
        /// </param>
        public UcSocketException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
