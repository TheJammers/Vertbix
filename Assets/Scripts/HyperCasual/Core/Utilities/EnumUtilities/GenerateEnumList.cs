using System;
using System.Collections.Generic;
using System.Linq;
using HyperCasual.Extensions;

namespace HyperCasual.Utilities
{
    /// <summary>
    /// Responsible for returning a value list of the given enum type.
    /// </summary>
    public static class GenerateEnumList
    {
        public static List<T> Perform<T>()
        {
            ValidateEnum.Perform<T>();

            var values = Enum.GetValues(typeof(T));
            return values.Cast<T>().ToList();
        }
    }
}
