using UnityEngine;

namespace HyperCasual.Extensions
{
    /// <summary>
    /// Extends the transform component with general reset operations.
    /// </summary>
    public static class TransformResetExtensions
    {
        public static Transform ResetGlobalRotation(this Transform transform)
        {
            transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
            return transform;
        }

        public static Transform ResetGlobalPosition(this Transform transform)
        {
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            return transform;
        }

        public static Transform ResetGlobal(this Transform transform)
        {
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);

            return transform;
        }

        public static Transform ResetLocalScale(this Transform transform)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            return transform;
        }

        public static Transform ResetLocalRotation(this Transform transform)
        {
            transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
            return transform;
        }

        public static Transform ResetLocalPosition(this Transform transform)
        {
            transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            return transform;
        }

        public static Transform ResetLocal(this Transform transform)
        {
            transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            return transform;
        }
    }
}
