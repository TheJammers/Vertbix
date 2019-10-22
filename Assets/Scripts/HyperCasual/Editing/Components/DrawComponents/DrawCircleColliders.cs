using System.Linq;
using UnityEngine;

namespace HyperCasual.Editing.Components
{
    /// <summary>
    /// Responsible for drawing all instances of the CircleCollider2D under its owning entity.
    /// </summary>
    [ExecuteInEditMode]
    public class DrawCircleColliders
        : MonoBehaviour
    {
        public Color Color = Color.green;

        public void OnDrawGizmos()
        {
            var collider_list = GetComponentsInChildren<CircleCollider2D>(true).ToList();
            for (var i = 0; i < collider_list.Count; ++i)
            {
                var circle_collider = collider_list[i];
                var circle_transform = circle_collider.transform;
                var circle_position = circle_transform.position;
                var circle_scale = FindLargestScale(circle_transform.lossyScale);

                var offset = circle_position + (Vector3) circle_collider.offset;
                var radius = circle_collider.radius*circle_scale;

                var color = circle_collider.gameObject.activeInHierarchy ? Color : Color*Color.grey;
                var points = GeneratePoints(radius, offset);
                for (var j = 1; j < points.Length; ++j)
                {
                    var end_index = j + 1 >= points.Length ? 1 : j + 1;

                    var start = points[j];
                    var end = points[end_index];
                    Debug.DrawLine(start, end, color);
                }
            }
        }

        private static Vector3[] GeneratePoints(float radius, Vector3 offset)
        {
            const int point_count = 33;
            const float angle_step = 360.0f/(point_count - 1);

            var points = new Vector3[point_count];
            points[0] = new Vector3(0.0f, 0.0f, 0.0f) + offset;

            var start_position = new Vector3(-radius, 0.0f, 0.0f);
            var angle = 0.0f;
            for (var i = 1; i < point_count; ++i)
            {
                points[i] = Quaternion.Euler(0.0f, 0.0f, angle)*start_position + offset;
                angle += angle_step;
            }

            return points;
        }

        private static float FindLargestScale(Vector3 scale)
        {
            var target = float.MinValue;
            if (scale.x > target)
                target = scale.x;

            if (scale.y > target)
                target = scale.y;

            return target;
        }
    }
}