// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuoteUpdateReason.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Update reason for quotes.
    /// </summary>
    public enum QuoteUpdateReason
    {
        /// <summary>
        ///    Bbo bid was updated.
        /// </summary>
        BboBid = 0,

        /// <summary>
        ///     Bbo Ask was updated.
        /// </summary>
        BboAsk
    }
}