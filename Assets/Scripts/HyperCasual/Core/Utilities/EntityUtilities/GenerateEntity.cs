using UnityEngine;

namespace HyperCasual.Utilities
{
    /// <summary>
    /// Provides common gameobject generators.
    /// </summary>
    public static class GenerateEntity
    {
        public static GameObject Perform()
        {
            return Perform("Entity", null);
        }

        public static GameObject Perform(Transform parent)
        {
            return Perform("Entity", parent);
        }

        public static GameObject Perform(string name)
        {
            return Perform("Entity", null);
        }

        public static GameObject Perform(string name, Transform parent)
        {
            var entity = new GameObject(name);
            entity.transform.parent = parent;
            entity.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            entity.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
            entity.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            return entity;
        }
    }
}
