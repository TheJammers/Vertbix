using UnityEngine;

namespace HyperCasual.Extensions
{
    /// <summary>
    /// Extends the color structure with common component operations.
    /// </summary>
    public static class ColorComponentExtensions
    {
        public static Color SetAlpha(this Color color, float alpha)
        {
            color.a = alpha;
            return color;
        }

        public static Color SetRGB(this Color color, Vector3 value)
        {
            color.r = value.x;
            color.g = value.y;
            color.b = value.z;
            return color;
        }

        public static Color SetRGB(this Color color, float r, float g, float b)
        {
            color.r = r;
            color.g = g;
            color.b = b;
            return color;
        }
    }
}
