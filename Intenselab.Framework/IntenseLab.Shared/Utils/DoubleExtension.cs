// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DoubleExtension.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.CompilerServices;

namespace IntenseLab.Shared.Utils
{
    /// <summary>
    ///     The double.
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        ///     The tolerance.
        /// </summary>
        private static double Tolerance { get; set; }= 0.0001 / 2;

        /// <summary>
        ///     Set the tolerance for comparing.
        /// </summary>
        /// <param name="current">
        ///     The current value.
        /// </param>
        /// <param name="value">
        ///     New tollerance value.
        /// </param>
        public static void SetTolerance(this double current, double value)
        {
            Tolerance = value / 2;
        }

        /// <summary>
        ///     Get tolerance.
        /// </summary>
        /// <param name="current">
        ///     The current value.
        /// </param>
        /// <returns>
        ///     The <see cref="double" />.
        /// </returns>
        public static double GetTolerance(this double current)
        {
            return Tolerance;
        }

        /// <summary>
        ///     The equals comparing with tollerance.
        /// </summary>
        /// <param name="current">
        ///     The current value.
        /// </param>
        /// <param name="valueToCompareWith">
        ///     The value for comparing with.
        /// </param>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equal(this double current, double valueToCompareWith)
        {
            return Math.Abs(current - valueToCompareWith) < Tolerance;
        }

        /// <summary>
        ///     The less or equal comparing with tollerance.
        /// </summary>
        /// <param name="current">
        ///     The current value.
        /// </param>
        /// <param name="valueToCompareWith">
        ///     The value for comparing with.
        /// </param>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool LessEqual(this double current, double valueToCompareWith)
        {
            return current <= valueToCompareWith || current.Equal(valueToCompareWith);
        }

        /// <summary>
        ///     The greater or equal comparing with tollerance.
        /// </summary>
        /// <param name="current">
        ///     The current value.
        /// </param>
        /// <param name="valueToCompareWith">
        ///     The value for comparing with.
        /// </param>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GreaterEqual(this double current, double valueToCompareWith)
        {
            return current >= valueToCompareWith || current.Equal(valueToCompareWith);
        }

        /// <summary>
        ///     The less comparing with tollerance.
        /// </summary>
        /// <param name="current">
        ///     The current value.
        /// </param>
        /// <param name="valueToCompareWith">
        ///     The value for comparing with.
        /// </param>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Less(this double current, double valueToCompareWith)
        {
            return !current.Equal(valueToCompareWith) && current < valueToCompareWith;
        }

        /// <summary>
        ///     The greater comparing with tollerance.
        /// </summary>
        /// <param name="current">
        ///     The current value.
        /// </param>
        /// <param name="valueToCompareWith">
        ///     The value for comparing with.
        /// </param>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Greater(this double current, double valueToCompareWith)
        {
            return !current.Equal(valueToCompareWith) && current > valueToCompareWith;
        }
    }
}