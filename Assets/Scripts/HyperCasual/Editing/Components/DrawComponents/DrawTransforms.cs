using System.Linq;
using UnityEngine;

namespace HyperCasual.Editing.Components
{
    /// <summary>
    /// Responsible for drawing a small marker for each transform in the hierarchy.
    /// </summary>
    [ExecuteInEditMode]
    public class DrawTransforms
        : MonoBehaviour
    {
        public float Radius = 0.1f;
        public Color Color = Color.white;

        public DrawTransforms SetColor(Color value)
        {
            Color = value;
            return this;
        }

        public DrawTransforms SetRadius(float value)
        {
            Radius = value;
            return this;
        }

        public void OnDrawGizmos()
        {
            var original_gizmo_color = Gizmos.color;
            var transforms = GetComponentsInChildren<Transform>(true).Where(element => element != transform).ToList();
            for (var i = 0; i < transforms.Count; ++i)
            {
                var target = transforms[i];
                Gizmos.color = target.gameObject.activeSelf ? Color : Color*Color.grey;
                Gizmos.DrawSphere(target.position, Radius);
            }

            Gizmos.color = original_gizmo_color;
        }
    }
}
