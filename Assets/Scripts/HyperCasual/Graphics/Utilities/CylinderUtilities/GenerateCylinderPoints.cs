using System.Collections.Generic;
using UnityEngine;

namespace HyperCasual.Graphics.Utilities
{
    /// <summary>
    /// Generates a list of points describing a cylinder mesh.
    /// </summary>
    public static class GenerateCylinderPoints
    {
        public static Vector3[] Perform(float radius, int circumfrance_point_count)
        {
            var top_offset = new Vector3(0.0f, +0.5f, 0.0f)*radius;
            var bottom_offset = new Vector3(0.0f, -0.5f, 0.0f)*radius;

            var points = new List<Vector3>();
            points.AddRange(GenerateCirclePoints.WithCenter(radius, top_offset, circumfrance_point_count));
            points.AddRange(GenerateCirclePoints.WithCenter(radius, bottom_offset, circumfrance_point_count));

            return points.ToArray();
        }
    }
}
