using HyperCasual.Interfaces;
using UnityEngine;

namespace HyperCasual.Extensions
{
    /// <summary>
    /// Extends the GameObject class with initialization routines.
    /// </summary>
    public static class EntityInitializeExtensions
    {
        public static T InitializeAll<T>(this T component) where T : Component
        {
            var this_target = component as IComponentInitializer;
            var check_for_this_target = this_target != null;

            var targets = component.GetComponentsInChildren<IComponentInitializer>(true);
            foreach (var target in targets)
            {
                if (check_for_this_target && target == this_target)
                    continue;

                Debug.LogFormat("{0}::Initializing::{1}", component.name, target.GetType().Name);
                target.Initialize();
            }

            return component;
        }

        public static GameObject InitializeAll(this GameObject entity)
        {
            var targets = entity.GetComponentsInChildren<IComponentInitializer>();
            foreach (var target in targets)
            {
                Debug.LogFormat("{0}::Initializing::{1}", entity.name, target.GetType().Name);
                target.Initialize();
            }

            return entity;
        }
    }
}
