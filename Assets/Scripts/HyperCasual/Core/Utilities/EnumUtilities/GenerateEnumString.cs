using HyperCasual.Extensions;

namespace HyperCasual.Utilities
{
    /// <summary>
    /// Provides enum utilities for generating common string representations.
    /// </summary>
    public static class GenerateEnumString
    {
        public static string NewLineSeparated<T>()
        {
            ValidateEnum.Perform<T>();
            var values = GenerateEnumList.Perform<T>();

            var output = values[0].ToString();
            for (var i = 0; i < values.Count - 1; ++i)
                output += "\n" + values[i + 1];

            return output;
        }

        public static string CommaSeperated<T>()
        {
            ValidateEnum.Perform<T>();
            var values = GenerateEnumList.Perform<T>();

            var output = values[0].ToString();
            for (var i = 0; i < values.Count - 1; ++i)
                output += ", " + values[i + 1];

            return output;
        }
    }
}
