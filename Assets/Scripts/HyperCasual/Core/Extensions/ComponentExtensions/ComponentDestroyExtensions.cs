using UnityEngine;

namespace HyperCasual.Extensions
{
    /// <summary>
    /// Extends the basic component class with common destruction operations.
    /// </summary>
    public static class ComponentDestroyExtensions
    {
        public static void DestroyComponentsInChildren<T>(this Component component, float time = 0.0f) where T : Component
        {
            var targets = component.GetComponentsInChildren<T>();
            foreach (var target in targets)
                Object.Destroy(target, time);
        }

        public static void DestroyComponent<T>(this Component component, float time = 0.0f) where T : Component
        {
            var target = component.GetComponent<T>();
            if (target != null)
                Object.Destroy(target, time);
        }
    }
}
