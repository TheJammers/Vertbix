using UnityEngine;
using UnityEditor;
using System.Linq;

namespace TopDownRace
{
    [CustomEditor(typeof(Segment))]
    public class SegmentEditor : Editor
    {
        void OnEnable()
        {
            var segment = (Segment)target;
            segment.Populate();
        }

        public void OnSceneGUI()
        {
            var segment = (Segment)target;
            if (segment == null)
                return;

            if (segment.joints == null || segment.joints.Any(j => j == null))
                SegmentSnapperEditor.Populate();

            for (int i = 0; i < segment.joints.Count; i++)
            {
                EditorGUI.BeginChangeCheck();

                var joint = segment.joints[i];
                Vector3 newTargetPosition = Handles.FreeMoveHandle(
                        joint.position,
                        Quaternion.identity,
                        HandleUtility.GetHandleSize(joint.position) * .25f,
                        Vector3.one * .01f,
                        Handles.SphereHandleCap);

                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(segment, "Joint move");
                    segment.transform.position += newTargetPosition - joint.transform.position;

                    CheckSnap(segment, joint);
                }
            }
        }

        void CheckSnap(Segment selectedSegment, Transform draggedJoint)
        {
            if (SegmentSnapperEditor.Segments == null)
                SegmentSnapperEditor.Populate();
            if (SegmentSnapperEditor.Segments.Any(s => s.joints.Any(j => j == null)))
                SegmentSnapperEditor.Populate();

            foreach (var segment in SegmentSnapperEditor.Segments)
            {
                if (segment == selectedSegment)
                    continue;
                Transform snapToJoint = segment.joints
                    .FirstOrDefault(j => (HandleUtility.WorldToGUIPoint(j.position) - HandleUtility.WorldToGUIPoint(draggedJoint.position)).magnitude < 35);

                if (snapToJoint == null)
                    continue;

                SegmentUtility.SnapJoints(selectedSegment.transform, draggedJoint, snapToJoint);
            }
        }

    }
}