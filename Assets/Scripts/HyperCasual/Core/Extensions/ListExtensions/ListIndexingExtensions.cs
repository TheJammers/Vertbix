using System.Collections.Generic;
using UnityEngine;

namespace HyperCasual.Extensions
{
    /// <summary>
    /// Extends generic lists with common indexing related operations.
    /// </summary>
    public static class ListIndexingExtensions
    {
        public static List<T> InsertLast<T>(this List<T> list, T target)
        {
            list.Insert(list.Count, target);
            return list;
        }

        public static List<T> InsertFirst<T>(this List<T> list, T target)
        {
            list.Insert(0, target);
            return list;
        }

        public static int GetRandomIndex<T>(this List<T> list)
        {
            if (list.IsNullOrEmpty())
                return -1;

            return Random.Range(0, list.Count);
        }
    }
}
