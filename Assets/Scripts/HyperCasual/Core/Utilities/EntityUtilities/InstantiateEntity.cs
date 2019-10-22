using System.Diagnostics;
using HyperCasual.Extensions;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace HyperCasual.Utilities.GameUtilities
{
    /// <summary>
    /// Provides utilities for common entity instantiation operations.
    /// </summary>
    public static class InstantiateEntity
    {
        public static bool OutputLog = true;

        public static T AndGet<T>(GameObject target) where T : Component
        {
            return Perform(target).GetComponent<T>();
        }

        public static T Perform<T>(T target) where T : Component
        {
            Log(target.name);
            return Object.Instantiate(target).SetName(target.name);
        }

        public static GameObject Perform(GameObject target)
        {
            Log(target.name);
            return Object.Instantiate(target).SetName(target.name);
        }

        [Conditional("DEBUG")]
        private static void Log(string name)
        {
            if (OutputLog)
                Debug.LogFormat("Instantiating::{0}", name);
            else
                OutputLog = true;

        }
    }
}
