using UnityEngine;

namespace HyperCasual.Extensions
{
    /// <summary>
    /// Extends the basic component class with common setters.
    /// </summary>
    public static class ComponentSetExtensions
    {
        public static T SetEntityActive<T>(this T component, bool value) where T : Component
        {
            component.gameObject.SetActiveState(value);
            return component;
        }

        public static T SetFlags<T>(this T component, HideFlags flags) where T : Component
        {
            component.hideFlags = flags;
            return component;
        }

        public static T SetEnabled<T>(this T component, bool value) where T : MonoBehaviour
        {
            component.enabled = value;
            return component;
        }

        public static T SetParent<T>(this T component, Transform parent) where T : Component
        {
            component.transform.parent = parent;
            return component;
        }
    }
}