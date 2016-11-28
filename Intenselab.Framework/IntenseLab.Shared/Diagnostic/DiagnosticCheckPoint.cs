// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagnosticCheckPoint.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace IntenseLab.Shared
{
    /// <summary>
    ///     Represents check point for <see cref="Diagnostics"/> class.
    /// </summary>
    public class DiagnosticCheckPoint
    {
        /// <summary>
        ///     Message of check point.
        /// </summary>
        public string Message { get; }

        /// <summary>
        ///     Period of time elapsed from last <see cref="Diagnostics.Start"/> invocation.
        /// </summary>
        public TimeSpan ElapsedTimePeriod { get; }


        /// <summary>
        ///     Create new instance of <see cref="DiagnosticCheckPoint"/>.
        /// </summary>
        /// <param name="message">
        ///     Message for check point.
        /// </param>
        /// <param name="elapsedTimePeriod">
        ///     Elapsed period of time.
        /// </param>
        public DiagnosticCheckPoint(string message, TimeSpan elapsedTimePeriod)
        {
            Message = message;
            ElapsedTimePeriod = elapsedTimePeriod;
        }
    }
}
