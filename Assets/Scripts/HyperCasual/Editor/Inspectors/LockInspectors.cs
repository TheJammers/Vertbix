using HyperCasual.Editing.Components;
using UnityEditor;

namespace HyperCasual.Editor.Inspectors
{
    [CustomEditor(typeof(PositionLock))]
    public class PositionLockInspector
        : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.Vector3Field("Position", ((PositionLock)target).Position);
        }
    }

    [CustomEditor(typeof(RotationLock))]
    public class RotationLockInspector
        : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.Vector3Field("Rotation", ((RotationLock) target).Rotation);
        }
    }

    [CustomEditor(typeof(ScaleLock))]
    public class ScaleLockInspector
        : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.Vector3Field("Scale", ((ScaleLock) target).Scale);
        }
    }
}
