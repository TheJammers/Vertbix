using System;

namespace HyperCasual.Extensions
{
    /// <summary>
    /// Responsible for throwing exception when given argument type is not an enum value.
    /// </summary>
    public static class ValidateEnum
    {
        public static void Perform<T>()
        {
            if (typeof(T).IsEnum)
                return;

            var msg = string.Format("input {0} is not an enum!", typeof(T).Name);
            throw new ArgumentException(msg);
        }
    }
}
