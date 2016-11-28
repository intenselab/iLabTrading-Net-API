// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BigNumbersFormatHelper.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;

namespace IntenseLab.Shared.Utils
{
    /// <summary>
    ///     Format helper for big numbers.
    /// </summary>
    public static class BigNumbersFormatHelper
    {
        /// <summary>
        ///     Format numbers bigger than 10 000 with spaces..
        /// </summary>
        /// <param name="value">
        ///     The specified value.
        /// </param>
        /// <returns>
        ///     Formatted value.
        /// </returns>
        public static string FormatBigNumber(long value)
        {
            return value >= 10000 ? value.ToString("n0") : value.ToString(CultureInfo.InvariantCulture);
        }
    }
}