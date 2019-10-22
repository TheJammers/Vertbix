using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace HyperCasual.Extensions
{
    /// <summary>
    /// Extends generic lists for common get operations.
    /// </summary>
    public static class ListGetExtensions
    {
        public static T GetLast<T>(this List<T> list)
        {
            return list[list.Count - 1];
        }

        public static T GetRandom<T>(this List<T> list)
        {
            var index = Random.Range(0, list.Count);
            return list[index];
        }

        public static T GetRandom<T>(this T[] list)
        {
            var index = Random.Range(0, list.Length);
            return list[index];
        }
    }
}
