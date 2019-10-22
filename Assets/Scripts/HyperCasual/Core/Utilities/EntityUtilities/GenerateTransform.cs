using UnityEngine;

namespace HyperCasual.Utilities
{
    /// <summary>
    /// Provides common utilities for generating a gameobject and returning its transform component.
    /// </summary>
    public static class GenerateTransform
    {
        public static Transform Perform()
        {
            return GenerateEntity.Perform().transform;
        }

        public static Transform Perform(Transform parent)
        {
            return GenerateEntity.Perform(parent).transform;
        }

        public static Transform Perform(string name)
        {
            return GenerateEntity.Perform(name).transform;
        }

        public static Transform Perform(string name, Transform parent)
        {
            return GenerateEntity.Perform(name, parent).transform;
        }
    }
}
