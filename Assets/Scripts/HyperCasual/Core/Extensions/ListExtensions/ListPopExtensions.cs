using System.Collections.Generic;

namespace HyperCasual.Extensions
{
    /// <summary>
    /// Extends generic lists with common popping operations.
    /// </summary>
    public static class ListPopExtensions
    {
        public static T PopLast<T>(this List<T> list)
        {
            return list.Pop(list.Count - 1);
        }

        public static T PopFirst<T>(this List<T> list)
        {
            return list.Pop(0);
        }

        public static T Pop<T>(this List<T> list, int index)
        {
            var item = list[index];
            list.RemoveAt(index);
            return item;
        }
    }
}
