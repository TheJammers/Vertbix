using System.Collections.Generic;
using System.Linq;

namespace HyperCasual.Extensions
{
    /// <summary>
    /// Extends generic lists with order-related operations.
    /// </summary>
    public static class ListOrderExtensions
    {
        public static List<T> GetReversedClone<T>(this List<T> list)
        {
            var clone = list.ToList();
            clone.Reverse();

            return clone;
        }

        public static List<T> MoveFirstToLast<T>(this List<T> list)
        {
            var item = list.PopFirst();
            list.Add(item);

            return list;
        }

        public static List<T> GetSortedClone<T>(this List<T> list)
        {
            return list.ToList().GetSorted();
        }

        public static List<T> GetSorted<T>(this List<T> list)
        {
            list.Sort();
            return list;
        }

        public static List<T> Shuffle<T>(this List<T> list)
        {
            var rng = new System.Random();
            var shuffled = list.ToList();

            var index = shuffled.Count;
            while (index > 1)
            {
                index--;
                var random_index = rng.Next(index + 1);

                var temp = shuffled[random_index];
                shuffled[random_index] = shuffled[index];
                shuffled[index] = temp;
            }

            return shuffled;
        }
    }
}
