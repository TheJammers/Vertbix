using UnityEngine;

namespace HyperCasual.Extensions
{
    /// <summary>
    /// Extends the transform component with common angles operations.
    /// </summary>
    public static class TransformAnglesExtensions
    {
        public static Transform SetGlobalAnglesYZ(this Transform transform, float y, float z)
        {
            var current = transform.eulerAngles;
            current.y = y;
            current.z = z;
            return transform.SetGlobalAngles(current);
        }

        public static Transform SetGlobalAnglesXZ(this Transform transform, float x, float z)
        {
            var current = transform.eulerAngles;
            current.x = x;
            current.z = z;
            return transform.SetGlobalAngles(current);
        }

        public static Transform SetGlobalAnglesXY(this Transform transform, float x, float y)
        {
            var current = transform.eulerAngles;
            current.x = x;
            current.y = y;
            return transform.SetGlobalAngles(current);
        }

        public static Transform SetGlobalAnglesZ(this Transform transform, float value)
        {
            var current = transform.eulerAngles;
            current.z = value;
            return transform.SetGlobalAngles(current);
        }

        public static Transform SetGlobalAnglesY(this Transform transform, float value)
        {
            var current = transform.eulerAngles;
            current.y = value;
            return transform.SetGlobalAngles(current);
        }

        public static Transform SetGlobalAnglesX(this Transform transform, float value)
        {
            var current = transform.eulerAngles;
            current.x = value;
            return transform.SetGlobalAngles(current);
        }

        public static Transform SetGlobalAngles(this Transform transform, Vector3 value)
        {
            transform.eulerAngles = value;
            return transform;
        }

        public static Transform SetLocalAnglesYZ(this Transform transform, float y, float z)
        {
            var current = transform.localEulerAngles;
            current.y = y;
            current.z = z;
            return transform.SetLocalAngles(current);
        }

        public static Transform SetLocalAnglesXZ(this Transform transform, float x, float z)
        {
            var current = transform.localEulerAngles;
            current.x = x;
            current.z = z;
            return transform.SetLocalAngles(current);
        }

        public static Transform SetLocalAnglesXY(this Transform transform, float x, float y)
        {
            var current = transform.localEulerAngles;
            current.x = x;
            current.y = y;
            return transform.SetLocalAngles(current);
        }

        public static Transform SetLocalAnglesZ(this Transform transform, float value)
        {
            var current = transform.localEulerAngles;
            current.z = value;
            return transform.SetLocalAngles(current);
        }

        public static Transform SetLocalAnglesY(this Transform transform, float value)
        {
            var current = transform.localEulerAngles;
            current.y = value;
            return transform.SetLocalAngles(current);
        }

        public static Transform SetLocalAnglesX(this Transform transform, float value)
        {
            var current = transform.localEulerAngles;
            current.x = value;
            return transform.SetLocalAngles(current);
        }

        public static Transform SetLocalAngles(this Transform transform, Vector3 value)
        {
            transform.localEulerAngles = value;
            return transform;
        }

        public static Transform SetAngles(this Transform transform, Vector3 value, ObjectSpace space)
        {
            if (space == ObjectSpace.Local)
                transform.localEulerAngles = value;
            else
                transform.eulerAngles = value;

            return transform;
        }

        public static Vector3 GetAngles(this Transform transform, ObjectSpace space)
        {
            return space == ObjectSpace.Local ? transform.localEulerAngles : transform.eulerAngles;
        }
    }
}
