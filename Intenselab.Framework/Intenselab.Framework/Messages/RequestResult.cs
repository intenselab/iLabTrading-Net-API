// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequestResult.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents result for request that requires confirmation (like update).
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class RequestResult : MessageWithId
    {
        /// <summary>
        ///     Result of the request.
        /// </summary>
        public RequestResultType RequestResultType { get; set; }

        /// <summary>
        ///     Additional information about result of request.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     Creats new instance of <see cref="RequestResult"/>.
        /// </summary>
        /// <param name="requestId">
        ///     Id of received request.
        /// </param>
        /// <param name="requestResultType">
        ///     Result of request.
        /// </param>
        /// <param name="message">
        ///     Additional information about result of request.
        /// </param>
        public RequestResult(int requestId, RequestResultType requestResultType,string message = "")
            : base(requestId)
        {
            RequestResultType = requestResultType;
            Message = message;
        }


        /// <summary>
        ///     Creats new instance of <see cref="RequestResult"/>.
        /// </summary>
        public RequestResult()
            : base(0)
        {
        }


        /// <summary>
        ///     Create result for specified request.
        /// </summary>
        /// <param name="request">
        ///     Processed request.
        /// </param>
        /// <param name="requestResultType">
        ///     Result of request.
        /// </param>
        /// <param name="message">
        ///     Additional information about result of request.
        /// </param>
        /// <returns>
        ///     Configured result for request.
        /// </returns>
        public static RequestResult MakeResult(MessageWithId request, RequestResultType requestResultType, string message = "")
        {
            return new RequestResult(request.RequestId, requestResultType, message);
        }
    }
}
