using System.Collections.Generic;

namespace HyperCasual.Extensions
{
    /// <summary>
    /// Extends generic lists with common query operations.
    /// </summary>
    public static class ListQueryExtensions
    {
        public static bool IsNullOrEmpty<T>(this List<T> list)
        {
            return list == null || list.Count == 0;
        }

        public static bool IsEmpty<T>(this List<T> list)
        {
            return list.Count == 0;
        }
    }
}