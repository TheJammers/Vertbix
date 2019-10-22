using UnityEngine;

namespace HyperCasual.Editing.Components
{
    /// <summary>
    /// Responsible for locking the owner's local scale.
    /// </summary>
    [ExecuteInEditMode]
    public class ScaleLock
        : MonoBehaviour, ILockComponent
    {
        public Vector3 Scale;

        public void Awake()
        {
            hideFlags = HideFlags.HideInInspector;
            UpdateCached();
        }

        public ScaleLock UpdateCached()
        {
            Scale = transform.localScale;
            return this;
        }

        public void PerformLock()
        {
            transform.localScale = Scale;
        }
    }
}
