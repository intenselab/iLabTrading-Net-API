// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupportedRoutesRequest.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents request for routes allowed for trading.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class SupportedRoutesRequest : MessageWithId
    {
        /// <summary>
        ///     Create new instance of <see cref="SupportedRoutesRequest"/>.
        /// </summary>
        public SupportedRoutesRequest() : base(0)
        {}

        /// <summary>
        ///     Create new instance of <see cref="SupportedRoutesRequest"/> with special id of request.
        /// </summary>
        public SupportedRoutesRequest(int requestId) : base(requestId)
        {}
    }
}
