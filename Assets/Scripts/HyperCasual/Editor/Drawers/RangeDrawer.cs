using HyperCasual.Data;
using UnityEditor;
using UnityEngine;

namespace HyperCasual.Editor.Drawers
{
    [CustomPropertyDrawer(typeof(Range))]
    public class RangeDrawer
        : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            var rect = new Rect(position.x, position.y, position.width*0.46f, position.height);
            EditorGUI.PropertyField(rect, property.FindPropertyRelative("Min"), GUIContent.none);

            rect = new Rect(rect.x + rect.width, position.y, position.width*0.04f, position.height);
            EditorGUI.LabelField(rect, "");

            rect = new Rect(rect.x + rect.width, position.y, position.width*0.5f, position.height);
            EditorGUI.PropertyField(rect, property.FindPropertyRelative("Max"), GUIContent.none);

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}