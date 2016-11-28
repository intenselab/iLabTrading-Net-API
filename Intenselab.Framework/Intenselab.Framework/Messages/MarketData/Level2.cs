// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Level2.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents composed bid from all accounts grouped by price and market maker ID. 
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class Level2 : MarketData
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Level2" /> class.
        /// </summary>
        public Level2()
            : base(MarketDataType.Level2)
        {
        }

        /// <summary>
        ///     Initializes copy of specified <see cref="level2"/>.
        /// </summary>
        /// <param name="level2">
        ///     Object for copy.
        /// </param>
        public Level2(Level2 level2)
            : base(MarketDataType.Level2)
        {
            Symbol = level2.Symbol;
            Price = level2.Price;
            Mmid = level2.Mmid;
            Level2Side = level2.Level2Side;
            Shares = level2.Shares;
        }

        /// <summary>
        ///     Gets or sets price of the bid.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        ///     Gets or sets the market maker id.
        /// </summary>
        public string Mmid { get; set; }

        /// <summary>
        ///     Gets or sets side of the bid.
        /// </summary>
        public Level2Side Level2Side { get; set; }

        /// <summary>
        ///     Gets or sets count of shares in current bid.
        /// </summary>
        public int Shares { get; set; }

        /// <summary>
        ///     <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return $"Level2: {Symbol} {Level2Side} {Shares} {Mmid} {Price}";
        }
    }
}