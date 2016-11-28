// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Level2Collection.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace IntenseLab.Shared.Utils
{
    /// <summary>
    ///     Represents collection sorted with specified comparer.
    /// </summary>
    /// <typeparam name="T">
    ///     <see cref="T"/>
    /// </typeparam>
    public class Level2Collection<T> : IEnumerable<T>
    {
        private IComparer<T> Comparer { get; }

        private List<T> Level2List { get; } = new List<T>();

        /// <summary>
        ///     Create new instance of with specified comparer.
        /// </summary>
        /// <param name="comparer">
        ///     Specified comparer for sorting collection.
        /// </param>
        public Level2Collection(IComparer<T> comparer)
        {
            Contract.Requires(comparer != null);
            Comparer = comparer;
        }

        /// <summary>
        ///     Create new instance from already existed <see cref="List{T}"/> with specified comparer.
        /// </summary>
        /// <param name="value">
        ///     Already existed <see cref="List{T}"/>
        /// </param>
        /// <param name="comparer">
        ///     Specified <see cref="IComparer{T}"/> for sorting collection.
        /// </param>
        public Level2Collection(List<T> value, IComparer<T> comparer)
        {
            Contract.Requires(value != null);
            Contract.Requires(comparer != null);

            Level2List = value;
            Level2List.Sort(comparer);
            Comparer = comparer;
        }

        /// <summary>
        ///     Get <see cref="IEnumerator{T}"/> of current collection.
        /// </summary>
        /// <returns>
        ///     <see cref="IEnumerator{T}"/>
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return Level2List.GetEnumerator();
        }

        /// <summary>
        ///     Get <see cref="IEnumerator"/> of current collection.
        /// </summary>
        /// <returns>
        ///     <see cref="IEnumerator"/>
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        /// <summary>
        ///     Add specified item of type <see cref="T"/> to current collection on position found by comparer.
        /// </summary>
        /// <param name="item">
        ///     Item to add.
        /// </param>
        /// <returns>
        ///     Result of operation. Operation will fail if the same item will be found.
        /// </returns>
        public bool Add(T item)
        {
            var index = Level2List.FindIndex(level2 => Comparer.Compare(level2, item) >= 0);

            if (index == -1)
            {
                index = Level2List.Count;
            }
            else
            {
                if (Comparer.Compare(Level2List[index], item) == 0)
                    return false;
            }
            
            Level2List.Insert(index, item);

            return true;
        }

        /// <summary>
        ///     Remove specified item from collection.
        /// </summary>
        /// <param name="item">
        ///     Item to remove.
        /// </param>
        /// <returns>
        ///     Result of operation.
        /// </returns>
        public bool Remove(T item)
        {
            return Level2List.Remove(item);
        }

        /// <summary>
        ///     Remove all items that satisfy specifed Predicate.
        /// </summary>
        /// <param name="predicate">
        ///     Condition for search.
        /// </param>
        /// <returns>
        ///     Count of items that were removed.
        /// </returns>
        public int RemoveWhere(Predicate<T> predicate)
        {
            if(predicate==null)
                throw new ArgumentNullException($"{nameof(predicate)}");

            var array = Level2List.ToList();

            var count = 0;
            foreach (var item in array)
            {
                if (!predicate(item))
                {
                    continue;
                }

                Remove(item);
                count++;
            }

            return count;
        }


        /// <summary>
        ///     Clear current collection.
        /// </summary>
        public void Clear()
        {
            Level2List.Clear();
        }

        /// <summary>
        ///     Count of itmes in current collection.
        /// </summary>
        public int Count => Level2List.Count;
    }
}
