using System.Linq;
using UnityEngine;

namespace HyperCasual.Editing.Components
{
    /// <summary>
    /// Responsible for drawing all instances of the BoxCollider2D found as children under the owning entity.
    /// </summary>
    [ExecuteInEditMode]
    public class DrawBoxColliders2D
        : MonoBehaviour
    {
        public Color Color = Color.green;

        public void OnDrawGizmos()
        {
            var collider_list = GetComponentsInChildren<BoxCollider2D>(true).ToList();
            for (var i = 0; i < collider_list.Count; ++i)
            {
                var box_collider = collider_list[i];
                var box_offset = (Vector3) box_collider.offset;
                var box_size = (Vector3) box_collider.size;
                var box_extents = box_size*0.5f;

                var box_root = box_collider.transform;
                var root_position = box_root.position;
                var root_rotation = box_root.rotation;
                var root_scale = box_root.lossyScale;

                var scaled_offset = Vector3.Scale(box_offset, root_scale);
                var rotated_offset = root_rotation*scaled_offset;
                var position = root_position + rotated_offset;
                var size = Vector3.Scale(box_extents, root_scale);

                var point_list = new Vector3[4];
                point_list[0] = (root_rotation*new Vector3(-size.x, -size.y, 0.0f)) + position;
                point_list[1] = (root_rotation*new Vector3(-size.x, +size.y, 0.0f)) + position;
                point_list[2] = (root_rotation*new Vector3(+size.x, +size.y, 0.0f)) + position;
                point_list[3] = (root_rotation*new Vector3(+size.x, -size.y, 0.0f)) + position;

                var color = box_root.gameObject.activeInHierarchy ? Color : Color*Color.grey;
                Debug.DrawLine(point_list[0], point_list[1], color);
                Debug.DrawLine(point_list[1], point_list[2], color);
                Debug.DrawLine(point_list[2], point_list[3], color);
                Debug.DrawLine(point_list[3], point_list[0], color);
            }
        }
    }
}