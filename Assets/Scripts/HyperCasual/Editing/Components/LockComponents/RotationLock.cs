using UnityEngine;

namespace HyperCasual.Editing.Components
{
    /// <summary>
    /// Responsible for locking the owner's local rotation.
    /// </summary>
    [ExecuteInEditMode]
    public class RotationLock
        : MonoBehaviour, ILockComponent
    {
        public Vector3 Rotation;

        public void Awake()
        {
            hideFlags = HideFlags.HideInInspector;
            UpdateCached();
        }

        public RotationLock UpdateCached()
        {
            Rotation = transform.localEulerAngles;
            return this;
        }

        public void PerformLock()
        {
            transform.localEulerAngles = Rotation;
        }
    }
}
