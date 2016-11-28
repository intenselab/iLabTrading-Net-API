// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupportedRoutesResponse.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents response on <see cref="SupportedRoutesRequest"/>
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class SupportedRoutesResponse : MessageWithId
    {
        /// <summary>
        ///     Represents configuration for allowed routes.
        /// </summary>
        public RoutesConfiguration RoutesConfiguration { get; set; }

        /// <summary>
        ///     Creates new instance of <see cref="SupportedRoutesResponse"/>.
        /// </summary>
        public SupportedRoutesResponse() : base(0)
        {}

        /// <summary>
        ///     Creates new instance of <see cref="SupportedRoutesResponse"/> with id of received request.
        /// </summary>
        public SupportedRoutesResponse(int requestId) : base(requestId)
        {}
    }
}
