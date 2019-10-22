using UnityEngine;

namespace HyperCasual.Extensions
{
    /// <summary>
    /// Extends the RectTransform with common reset operations.
    /// </summary>
    public static class RectTransformResetExtensions
    {
        public static RectTransform ResetLocalRect(this RectTransform transform)
        {
            transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            transform.sizeDelta = new Vector2(0.0f, 0.0f);

            return transform;
        }
    }
}
