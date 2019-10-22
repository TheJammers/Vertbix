using UnityEngine;

namespace HyperCasual.Extensions
{
    /// <summary>
    /// Provides game object extensions for setting common data.
    /// </summary>
    public static class EntitySetExtensions
    {
        public static GameObject SetTag(this GameObject entity, string value)
        {
            entity.tag = value;
            return entity;
        }

        public static GameObject SetActiveState(this GameObject entity, bool value)
        {
            Debug.LogFormat("{0}::Set Active::{1}", entity.name, value);
            entity.SetActive(value);

            return entity;
        }

        public static GameObject SetParent(this GameObject entity, Transform parent)
        {
            entity.transform.parent = parent;
            return entity;
        }

        public static GameObject SetLayerHierarchy(this GameObject entity, int layer)
        {
            var transforms = entity.GetComponentsInChildren<Transform>(true);
            for (var i = 0; i < transforms.Length; ++i)
                transforms[i].gameObject.layer = layer;

            return entity;
        }

        public static GameObject SetLayer(this GameObject entity, int layer)
        {
            entity.layer = layer;
            return entity;
        }

        public static GameObject SetLayerHierarchy(this GameObject entity, string layer_name)
        {
            var layer = LayerMask.NameToLayer(layer_name);
            var transforms = entity.GetComponentsInChildren<Transform>(true);
            for (var i = 0; i < transforms.Length; ++i)
                transforms[i].gameObject.layer = layer;

            return entity;
        }

        public static GameObject SetLayer(this GameObject entity, string layer_name)
        {
            entity.layer = LayerMask.NameToLayer(layer_name);
            return entity;
        }

        public static GameObject SetFlags(this GameObject entity, HideFlags value)
        {
            entity.hideFlags = value;
            return entity;
        }

        public static GameObject SetName(this GameObject entity, string value)
        {
            entity.name = value;
            return entity;
        }
    }
}
