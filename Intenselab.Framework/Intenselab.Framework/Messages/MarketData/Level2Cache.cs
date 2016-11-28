// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Level2Cache.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using IntenseLab.Shared.Utils;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents snapshot of order book at current moment. 
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public sealed class Level2Cache : MarketData
    {
        private readonly object syncRoot = new object();
        private Level2Collection<Level2> askBox = new Level2Collection<Level2>(new Level2AskComparer());
        private Level2Collection<Level2> bidBox = new Level2Collection<Level2>(new Level2BidComparer());

        /// <summary>
        ///     Create new instance of <see cref="Level2Cache"/>
        /// </summary>
        public Level2Cache()
            : base(MarketDataType.Level2Cache)
        {
        }

        /// <summary>
        ///     Initialize the <see cref="Level2Cache" /> class for symbol.
        /// </summary>
        /// <param name="symbol">
        ///     Abbreviation for stock name.
        /// </param>
        public Level2Cache(string symbol)
            : base(MarketDataType.Level2Cache)
        {
            Symbol = symbol;
        }

        /// <summary>
        ///     Initialize the <see cref="Level2Cache" /> class from another cache.
        /// </summary>
        /// <param name="level2Cache">
        ///     Cache for copying.
        /// </param>
        /// <param name="limit">
        ///     The ask/bid collection's records limit.
        ///     (Don't use now).
        /// </param>
        public Level2Cache(Level2Cache level2Cache, int limit)
            : base(MarketDataType.Level2Cache)
        {
            AskBox = level2Cache.AskBox;
            BidBox = level2Cache.BidBox;

            Symbol = level2Cache.Symbol;
        }

        /// <summary>
        ///     Gets or sets collection of records with <see cref="Level2Side.Ask"/>.
        /// </summary>
        public List<Level2> AskBox
        {
            get
            {
                lock (syncRoot)
                {
                    return askBox.ToList();
                }
            }

            set
            {
                lock (syncRoot)
                {
                    askBox = new Level2Collection<Level2>(value, new Level2AskComparer());
                }
            }
        }

        /// <summary>
        ///      Gets or sets collection of records with <see cref="Level2Side.Bid"/>.
        /// </summary>
        public List<Level2> BidBox
        {
            get
            {
                lock (syncRoot)
                {
                    return bidBox.ToList();
                }
            }

            set
            {
                lock (syncRoot)
                {
                    bidBox = new Level2Collection<Level2>(value, new Level2BidComparer());
                }
            }
        }

        /// <summary>
        ///     Add, remove or update item in cache.
        /// </summary>
        /// <param name="level2">
        ///     Item for processing.
        /// </param>
        public void OnLevel2(Level2 level2)
        {
            lock (syncRoot)
            {
                if (level2 == null || level2.Price.Equals(0))
                {
                    return;
                }

                var level2Box = GetLevel2BoxBySide(level2);

                var list = level2Box.ToList();


                if (level2.Shares == 0)
                {
                    level2Box.RemoveWhere(level2Item => level2Item.Price.Equal(level2.Price) && string.Equals(level2Item.Mmid, level2.Mmid));
                }
                else
                {
                    level2.Price = Math.Round(level2.Price, 2);
                    var cachedLevel2 = list.FirstOrDefault(level2Item => level2Item.Price.Equal(level2.Price) && string.Equals(level2Item.Mmid, level2.Mmid));

                    if (cachedLevel2 != null)
                        level2Box.Remove(cachedLevel2);

                    level2Box.Add(level2);
                }
            }
        }

        private Level2Collection<Level2> GetLevel2BoxBySide(Level2 level2)
        {
            return level2.Level2Side == Level2Side.Ask ? askBox : bidBox;
        }

        /// <summary>
        ///     Get the best price for stock on bid side.
        /// </summary>
        /// <returns>
        ///     The best price on bid side.
        /// </returns>
        public double GetBestBidPrice()
        {
            lock (syncRoot)
            {
                return bidBox.Count > 0 ? bidBox.First().Price : 0;
            }
        }

        /// <summary>
        ///     Get the best price for stock on ask side.
        /// </summary>
        /// <returns>
        ///     The best price on ask side.
        /// </returns>
        public double GetBestAskPrice()
        {
            lock (syncRoot)
            {
                return askBox.Count > 0 ? askBox.First().Price : 0;
            }
        }

        /// <summary>
        ///     Get the best price for stock on bid side with specified MMID.
        /// </summary>
        /// <param name="mmid">
        ///     Market maker Id.
        /// </param>
        /// <returns>
        ///     The best price on bid side with specified MMID.
        /// </returns>
        public double GetBestBidPrice(string mmid)
        {
            lock (syncRoot)
            {
                var filteredRecords = bidBox.Where(level2 => string.Equals(level2.Mmid, mmid)).ToList();

                return filteredRecords.Count == 0 ?
                    0 :
                    filteredRecords.Max(level2 => level2.Price);
            }
        }

        /// <summary>
        ///     Get the best price for stock on ask side with specified MMID.
        /// </summary>
        /// <param name="mmid">
        ///     Market maker Id.
        /// </param>
        /// <returns>
        ///     The best price on ask side with specified MMID.
        /// </returns>
        public double GetBestAskPrice(string mmid)
        {
            lock (syncRoot)
            {
                var filteredRecords = askBox.Where(level2 => string.Equals(level2.Mmid, mmid)).ToList();

                return filteredRecords.Count == 0 ?
                    0 :
                    filteredRecords.Min(level2 => level2.Price);
            }
        }

        /// <summary>
        ///     Get best bid item for stock with special MMID.
        /// </summary>
        /// <param name="mmid">
        ///     Market maker Id.
        /// </param>
        /// <returns>
        ///     Found item or NULL if item with specified MMID wasn't found.
        /// </returns>
        public Level2 GetBestBidItem(string mmid)
        {
            lock (syncRoot)
            {
                var filteredRecords = bidBox.Where(level2 => string.Equals(level2.Mmid, mmid)).ToList();

                if (filteredRecords.Count == 0)
                    return null;

                var bestBid = filteredRecords.MaxBy(level2 => level2.Price);
                return bestBid;
            }
        }

        /// <summary>
        ///     Get best ask item for stock with special MMID.
        /// </summary>
        /// <param name="mmid">
        ///     Market maker Id.
        /// </param>
        /// <returns>
        ///     Found item or NULL if item with specified MMID wasn't found.
        /// </returns>
        public Level2 GetBestAskItem(string mmid)
        {
            lock (syncRoot)
            {
                var filteredRecords = askBox.Where(level2 => string.Equals(level2.Mmid, mmid)).ToList();

                if (filteredRecords.Count == 0)
                    return null;

                var bestAsk = filteredRecords.MinBy(level2 => level2.Price);
                return bestAsk;
            }
        }

        /// <summary>
        ///     Clear ask and bid collections.
        /// </summary>
        public void Clear()
        {
            lock (syncRoot)
            {
                bidBox.Clear();
                askBox.Clear();
            }
        }

        /// <summary>
        ///     Truncate top of Bid collection by specified price.
        /// </summary>
        /// <param name="priceForTrancating">
        ///     Price for trancating
        /// </param>
        public void TruncateBidCollection(double priceForTrancating)
        {
            lock (syncRoot)
            {
                bidBox.RemoveWhere(level2 => level2.Price > priceForTrancating);
            }
        }

        /// <summary>
        ///     Truncate top of Ask collection by specified price.
        /// </summary>
        /// <param name="priceForTrancating">
        ///     Price for trancating
        /// </param>
        public void TruncateAskCollection(double priceForTrancating)
        {
            lock (syncRoot)
            {
                askBox.RemoveWhere(level2 => level2.Price < priceForTrancating);
            }
        }

        /// <summary>
        ///     Reset cache, copying records from specified cache.
        /// </summary>
        /// <param name="level2Cache">
        ///     New level2 cache.
        /// </param>
        public void ResetCache(Level2Cache level2Cache)
        {
            lock (syncRoot)
            {
                BidBox = level2Cache.BidBox;
                AskBox = level2Cache.AskBox;
            }
        }

        /// <summary>
        ///     Get level2 cache with limited count of records in Ask and Bid collections.
        /// </summary>
        /// <param name="limit">
        ///     Count of records in each collection.
        /// </param>
        /// <returns>
        ///     Limited cache. 
        /// </returns>
        public Level2Cache GetLimitedCache(int limit)
        {
            lock (syncRoot)
            {
                return new Level2Cache(this, limit);
            }
        }

        #region Bid/Ask comparers

        /// <summary>
        ///     Comparer for records in collection with Ask side.
        /// </summary>
        public class Level2AskComparer : Comparer<Level2>
        {
            /// <summary>
            ///     Compare two items of type <see cref="Level2"/> by rule for Ask side
            /// </summary>
            public override int Compare(Level2 item1, Level2 item2)
            {
                if (item1 == null)
                    throw new ArgumentNullException(nameof(item1));

                if (item2 == null)
                    throw new ArgumentNullException(nameof(item2));

                var compareResult = Math.Round(item1.Price, 2).CompareTo(Math.Round(item2.Price, 2));

                if (compareResult == 0)
                    compareResult = item2.Shares.CompareTo(item1.Shares);


                return compareResult == 0 ? string.Compare(item1.Mmid, item2.Mmid, StringComparison.Ordinal) : compareResult;
            }
        }

        /// <summary>
        ///     Comparer for records in collection with Bid side.
        /// </summary>
        public class Level2BidComparer : Comparer<Level2>
        {
            /// <summary>
            ///     Compare two items of type <see cref="Level2"/> by rule for Bid side
            /// </summary>
            public override int Compare(Level2 item1, Level2 item2)
            {
                if (item1 == null)
                    throw new ArgumentNullException(nameof(item1));

                if (item2 == null)
                    throw new ArgumentNullException(nameof(item2));

                var compareResult = Math.Round(item2.Price, 2).CompareTo(Math.Round(item1.Price, 2));

                if (compareResult == 0)
                    compareResult = item2.Shares.CompareTo(item1.Shares);


                return compareResult == 0 ? string.Compare(item1.Mmid, item2.Mmid, StringComparison.Ordinal) : compareResult;
            }
        }

        #endregion
    }
}