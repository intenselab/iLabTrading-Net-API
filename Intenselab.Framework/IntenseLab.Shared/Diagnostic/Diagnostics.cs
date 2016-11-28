// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Diagnostics.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace IntenseLab.Shared
{
    /// <summary>
    ///     Represents object for monitoring time of action execution.
    /// </summary>
    public class Diagnostics
    {
        /// <summary>
        ///     Stopwatch, which control elapsed time.
        /// </summary>
        private Stopwatch Stopwatch { get; } = new Stopwatch();

        /// <summary>
        ///     Collection of registered checkpoints.
        /// </summary>
        private List<DiagnosticCheckPoint> CheckPointsCollection { get; } = new List<DiagnosticCheckPoint>();

        /// <summary>
        ///     Period of time that has elapsed from <see cref="Start"/> to <see cref="Stop"/>.
        /// </summary>
        public TimeSpan FullTimeElapsed { get; private set; }

        /// <summary>
        ///     Collection of registered checkpoints.
        /// </summary>
        public IReadOnlyCollection<DiagnosticCheckPoint> CheckPoints => CheckPointsCollection.AsReadOnly();
        

        /// <summary>
        ///     Start time watcher and clear collection of check points.
        /// </summary>
        public void Start()
        {
            CheckPointsCollection.Clear();
            Stopwatch.Restart();
        }

        /// <summary>
        ///     Stop time watcher and save full elapsed time.
        /// </summary>
        public void Stop()
        {
            Stopwatch.Stop();
            FullTimeElapsed = Stopwatch.Elapsed;
        }

        /// <summary>
        ///     Add new check point with specified message and period of time elapsed from <see cref="Start"/>.
        /// </summary>
        /// <param name="message">
        ///     Message which will be assigned to check point.
        /// </param>
        public void AddCheckpoint(string message)
        {
            var checkPoint = new DiagnosticCheckPoint(message, Stopwatch.Elapsed);
            CheckPointsCollection.Add(checkPoint);
        }
    }
}
