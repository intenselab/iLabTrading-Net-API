// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Print.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents confirmation of transaction between two trading accounts.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class Print : MarketData
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Print" /> class.
        /// </summary>
        public Print()
            : base(MarketDataType.Print)
        {
        }

        /// <summary>
        ///     Gets or sets price of transaction.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        ///     Gets or sets count of shares in transaction.
        /// </summary>
        public int Shares { get; set; }

        /// <summary>
        ///     Gets or sets exchange of transaction.
        /// </summary>
        public string Exchange { get; set; }

        /// <summary>
        ///     <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return $"Print:{Symbol},{Time},{Price},{Shares},{Exchange}";
        }
    }
}