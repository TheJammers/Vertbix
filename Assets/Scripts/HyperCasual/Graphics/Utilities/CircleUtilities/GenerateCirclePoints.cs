using UnityEngine;

namespace HyperCasual.Graphics.Utilities
{
    /// <summary>
    /// Responsible for generating a list of points describing a circle.
    /// </summary>
    public static class GenerateCirclePoints
    {
        public static Vector3[] CircumfranceOnly(float radius, Vector3 offset, int point_count)
        {
            var angle_step = 360.0f/point_count;
            var start = new Vector3(0.0f, 0.0f, -0.5f)*radius;

            var points = new Vector3[point_count];
            for (var i = 0; i < point_count; ++i)
            {
                var angle = angle_step*i;
                var rotation = Quaternion.Euler(0.0f, angle, 0.0f);
                var point = rotation*start + offset;
                points[i] = point;
            }

            return points;
        }

        public static Vector3[] WithCenter(float radius, Vector3 offset, int point_count)
        {
            var angle_step = 360.0f/point_count;
            var start = new Vector3(0.0f, 0.0f, -0.5f)*radius;

            var points = new Vector3[point_count + 1];
            points[0] = offset;

            for (var i = 0; i < point_count; ++i)
            {
                var angle = angle_step*i;
                var rotation = Quaternion.Euler(0.0f, angle, 0.0f);
                var point = rotation*start + offset;
                points[i + 1] = point;
            }

            return points;
        }
    }
}