using UnityEditor;
using UnityEngine;

namespace TopDownRace
{
    public static class SegmentUtility
    {
        public static void SnapJoints(Transform selectedSegmentTransform, Transform selectedJoint, Transform snapJoin)
        {
            Undo.RecordObject(selectedSegmentTransform, "Joint snap");
            selectedSegmentTransform.rotation = snapJoin.rotation;
            selectedSegmentTransform.Rotate(new Vector3(.0f, 1.0f, .0f), 180.0f - selectedJoint.localRotation.eulerAngles.y);

            var diffTranslate = snapJoin.position - selectedJoint.position;
            selectedSegmentTransform.position += diffTranslate;
        }
    }
}