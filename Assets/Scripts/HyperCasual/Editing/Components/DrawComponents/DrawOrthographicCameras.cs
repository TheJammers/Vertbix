using System.Linq;
using UnityEngine;

namespace HyperCasual.Editing.Components
{
    /// <summary>
    /// Responsible for drawing the bounds of all children orthographic cameras.
    /// </summary>
    [ExecuteInEditMode]
    public class DrawOrthographicCameras
        : MonoBehaviour
    {
        public Color Color = Color.white;

        public void OnDrawGizmos()
        {
            var camera_list = GetComponentsInChildren<Camera>(true).Where(element => element.orthographic).ToList();
            foreach (var target in camera_list)
            {
                var half_width = target.orthographicSize*target.aspect;
                var size = new Vector3(half_width*2.0f, target.orthographicSize*2.0f, target.depth);
                var bounds = new Bounds(Vector3.zero, size);

                var point_list = new Vector3[4];
                point_list[0] = new Vector3(bounds.min.x, bounds.min.y, 0.0f);
                point_list[1] = new Vector3(bounds.min.x, bounds.max.y, 0.0f);
                point_list[2] = new Vector3(bounds.max.x, bounds.max.y, 0.0f);
                point_list[3] = new Vector3(bounds.max.x, bounds.min.y, 0.0f);

                for (var i = 0; i < point_list.Length; ++i)
                {
                    point_list[i] = target.transform.rotation*point_list[i];
                    point_list[i] += target.transform.position;
                }

                var color = target.gameObject.activeInHierarchy ? Color : Color*Color.grey;
                Debug.DrawLine(point_list[0], point_list[1], color);
                Debug.DrawLine(point_list[1], point_list[2], color);
                Debug.DrawLine(point_list[2], point_list[3], color);
                Debug.DrawLine(point_list[3], point_list[0], color);
            }
        }
    }
}