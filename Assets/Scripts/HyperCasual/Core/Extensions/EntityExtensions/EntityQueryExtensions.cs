using UnityEngine;

namespace HyperCasual.Extensions
{
    /// <summary>
    /// Extends the GameObject class with common queries.
    /// </summary>
    public static class EntityQueryExtensions
    {
        public static GameObject FindNamedChild(this GameObject entity, string target_name)
        {
            var children = entity.GetComponentsInChildren<Transform>(true);
            foreach (var child in children)
            {
                if (child.name == target_name)
                    return child.gameObject;
            }

            return null;
        }
    }
}
