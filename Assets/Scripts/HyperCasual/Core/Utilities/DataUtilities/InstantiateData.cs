using HyperCasual.Extensions;
using UnityEngine;

namespace HyperCasual.Utilities
{
    /// <summary>
    /// Provides utilities for easily instantiating new scriptable objects.
    /// </summary>
    public static class InstantiateData
    {
        public static T Perform<T>(T target) where T : ScriptableObject
        {
            Debug.LogFormat("Instantiating::{0}", target.name);
            return Object.Instantiate(target).SetName(target.name);
        }
    }
}
