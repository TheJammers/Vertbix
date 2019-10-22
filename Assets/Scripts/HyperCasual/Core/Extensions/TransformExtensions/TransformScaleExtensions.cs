using System;
using UnityEngine;

namespace HyperCasual.Extensions
{
    /// <summary>
    /// Extends the transform component with common scale operations.
    /// </summary>
    public static class TransformScaleExtensions
    {
        public static Transform SetLocalScaleYZ(this Transform transform, float y, float z)
        {
            var current = transform.localScale;
            current.y = y;
            current.z = z;
            return transform.SetLocalScale(current);
        }

        public static Transform SetLocalScaleXZ(this Transform transform, float x, float z)
        {
            var current = transform.localScale;
            current.x = x;
            current.z = z;
            return transform.SetLocalScale(current);
        }

        public static Transform SetLocalScaleXY(this Transform transform, float x, float y)
        {
            var current = transform.localScale;
            current.x = x;
            current.y = y;
            return transform.SetLocalScale(current);
        }

        public static Transform SetLocalScaleZ(this Transform transform, float value)
        {
            var current = transform.localScale;
            current.z = value;
            return transform.SetLocalScale(current);
        }

        public static Transform SetLocalScaleY(this Transform transform, float value)
        {
            var current = transform.localScale;
            current.y = value;
            return transform.SetLocalScale(current);
        }

        public static Transform SetLocalScaleX(this Transform transform, float value)
        {
            var current = transform.localScale;
            current.x = value;
            return transform.SetLocalScale(current);
        }

        public static Transform SetLocalScale(this Transform transform, Vector3 value)
        {
            transform.localScale = value;
            return transform;
        }

        public static Transform SetScale(this Transform transform, Vector3 value, ObjectSpace space)
        {
            if (space == ObjectSpace.Local)
                transform.localScale = value;
            else
                throw new NotImplementedException("unable to set global scale on objects");

            return transform;
        }

        public static Vector3 GetScale(this Transform transform, ObjectSpace space)
        {
            return space == ObjectSpace.Local ? transform.localScale : transform.lossyScale;
        }
    }
}
