using UnityEngine;

namespace HyperCasual.Extensions
{
    /// <summary>
    /// Extends the base unity object with common setters.
    /// </summary>
    public static class ObjectSetExtensions
    {
        public static T SetName<T>(this T component, string value) where T : Object
        {
            component.name = value;
            return component;
        }
    }
}
