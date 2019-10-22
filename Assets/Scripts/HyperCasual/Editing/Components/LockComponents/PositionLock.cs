using UnityEngine;

namespace HyperCasual.Editing.Components
{
    /// <summary>
    /// Responsible for locking the owner's local position.
    /// </summary>
    [ExecuteInEditMode]
    public class PositionLock
        : MonoBehaviour, ILockComponent
    {
        public Vector3 Position;

        public void Awake()
        {
            hideFlags = HideFlags.HideInInspector;
            UpdateCached();
        }

        public PositionLock UpdateCached()
        {
            Position = transform.localPosition;
            return this;
        }

        public void PerformLock()
        {
            transform.localPosition = Position;
        }
    }
}
