// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RiskInfoesResponse.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.Composition;
using IntenseLab.Shared.Attributes;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents repsonse on <see cref="AdminRequest"/> with type equals to <see cref="AdminRequestType.AllRiskInfoes"/>
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class RiskInfoesResponse : MessageWithId
    {
        /// <summary>
        ///     Collection of <see cref="RiskInfo"/>.
        /// </summary>
        public List<RiskInfo> RiskInfoes { get; set; }

        /// <summary>
        ///     Initialize the <see cref="RiskInfoesResponse"/> class with special request Id.
        /// </summary>
        /// <param name="requestId">
        ///     Id of request.
        /// </param>
        public RiskInfoesResponse(int requestId)
            : base(requestId)
        {
        }

        /// <summary>
        ///     Initialize the <see cref="RiskInfoesResponse"/> class.
        /// </summary>
        public RiskInfoesResponse()
            : base(0)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RiskInfoesResponse" /> class 
        ///     with specified collection of <see cref="RiskInfo"/> and Id of received request.
        /// </summary>
        /// <param name="requestId">
        ///     Id of the received request.
        /// </param>
        /// <param name="riskInfoes">
        ///     Collection of <see cref="RiskInfo"/>.
        /// </param>
        public RiskInfoesResponse(int requestId, List<RiskInfo> riskInfoes)
            : base(requestId)
        {
            RiskInfoes = riskInfoes;
        }
    }
}