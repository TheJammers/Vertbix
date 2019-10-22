using HyperCasual.Editor.Utilities;
using UnityEngine;

namespace HyperCasual.Editor.Extensions
{
    /// <summary>
    /// Extends the GameObject class with editor-specific operations.
    /// </summary>
    public static class EntityEditorExtensions
    {
        public static GameObject EditorRemoveComponent<T>(this GameObject entity) where T : Component
        {
            var target = entity.GetComponent<T>();
            if (target != null)
                Object.DestroyImmediate(target);

            return entity;
        }

        public static T SetLabelIcon<T>(this T target, int icon_index) where T : Component
        {
            SetEntityLabelIcon.Perform(target.gameObject, icon_index);
            return target;
        }

        public static GameObject SetLabelIcon(this GameObject target, int icon_index)
        {
            return SetEntityLabelIcon.Perform(target, icon_index);
        }
    }
}