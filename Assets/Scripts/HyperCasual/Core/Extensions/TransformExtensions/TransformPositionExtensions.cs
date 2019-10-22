using UnityEngine;

namespace HyperCasual.Extensions
{
    /// <summary>
    /// Extends the transform component with common position operations.
    /// </summary>
    public static class TransformPositionExtensions
    {
        public static Transform SetGlobalPositionYZ(this Transform transform, float y, float z)
        {
            var current = transform.position;
            current.y = y;
            current.z = z;
            return transform.SetGlobalPosition(current);
        }

        public static Transform SetGlobalPositionXZ(this Transform transform, float x, float z)
        {
            var current = transform.position;
            current.x = x;
            current.z = z;
            return transform.SetGlobalPosition(current);
        }

        public static Transform SetGlobalPositionXY(this Transform transform, float x, float y)
        {
            var current = transform.position;
            current.x = x;
            current.y = y;
            return transform.SetGlobalPosition(current);
        }

        public static Transform SetGlobalPositionZ(this Transform transform, float value)
        {
            var current = transform.position;
            current.z = value;
            return transform.SetGlobalPosition(current);
        }

        public static Transform SetGlobalPositionY(this Transform transform, float value)
        {
            var current = transform.position;
            current.y = value;
            return transform.SetGlobalPosition(current);
        }

        public static Transform SetGlobalPositionX(this Transform transform, float value)
        {
            var current = transform.position;
            current.x = value;
            return transform.SetGlobalPosition(current);
        }

        public static Transform SetGlobalPosition(this Transform transform, Vector3 value)
        {
            transform.position = value;
            return transform;
        }

        public static Transform SetLocalPositionYZ(this Transform transform, float y, float z)
        {
            var current = transform.localPosition;
            current.y = y;
            current.z = z;
            return transform.SetLocalPosition(current);
        }

        public static Transform SetLocalPositionXZ(this Transform transform, float x, float z)
        {
            var current = transform.localPosition;
            current.x = x;
            current.z = z;
            return transform.SetLocalPosition(current);
        }

        public static Transform SetLocalPositionXY(this Transform transform, float x, float y)
        {
            var current = transform.localPosition;
            current.x = x;
            current.y = y;
            return transform.SetLocalPosition(current);
        }

        public static Transform SetLocalPositionZ(this Transform transform, float value)
        {
            var current = transform.localPosition;
            current.z = value;
            return transform.SetLocalPosition(current);
        }

        public static Transform SetLocalPositionY(this Transform transform, float value)
        {
            var current = transform.localPosition;
            current.y = value;
            return transform.SetLocalPosition(current);
        }

        public static Transform SetLocalPositionX(this Transform transform, float value)
        {
            var current = transform.localPosition;
            current.x = value;
            return transform.SetLocalPosition(current);
        }

        public static Transform SetLocalPosition(this Transform transform, Vector3 value)
        {
            transform.localPosition = value;
            return transform;
        }

        public static Transform SetPosition(this Transform transform, Vector3 value, ObjectSpace space)
        {
            if (space == ObjectSpace.Local)
                transform.localPosition = value;
            else
                transform.position = value;

            return transform;
        }

        public static Vector3 GetPosition(this Transform transform, ObjectSpace space)
        {
            return space == ObjectSpace.Local ? transform.localPosition : transform.position;
        }
    }
}
