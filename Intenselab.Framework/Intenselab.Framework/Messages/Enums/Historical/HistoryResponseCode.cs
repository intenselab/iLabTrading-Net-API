// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HistoricalResponseCode.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents code of response on <see cref="HistoricalDataRequest"/>.
    /// </summary>
    public enum HistoricalResponseCode
    {
        /// <summary>
        ///     Request was sucessfull.
        /// </summary>
        Success = 0,

        /// <summary>
        ///     Request was failed because of time had out.
        /// </summary>
        RequestTimeOut,

        /// <summary>
        ///     Some other error cause failure of <see cref="HistoricalDataRequest"/>
        /// </summary>
        OtherError,

        /// <summary>
        ///     Code that correspond tp request on performance test stock. 
        /// </summary>
        PerformanceTest
    }
}
