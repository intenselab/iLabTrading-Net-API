// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdminRequest.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents request from admin user for some additional information about users and accounts.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class AdminRequest : MessageWithId
    {
        /// <summary>
        ///     Type of requested information.
        /// </summary>
        public AdminRequestType RequestType { get; set; }

        /// <summary>
        ///     Initialize the <see cref="AdminRequest"/> class.
        /// </summary>
        public AdminRequest()
            : base(0)
        {
        }

        /// <summary>
        ///     Initialize the <see cref="AdminRequest"/> class with special request Id.
        /// </summary>
        /// <param name="requestId">
        ///     Id of request.
        /// </param>
        public AdminRequest(int requestId)
            : base(requestId)
        {
        }

        /// <summary>
        ///     <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return $"RequestType:{RequestType}, RequestId:{RequestId}";
        }
    }
}