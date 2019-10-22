using HyperCasual.Data;
using UnityEditor;
using UnityEngine;

namespace HyperCasual.Editor.Drawers
{
    [CustomPropertyDrawer(typeof(RandomInt))]
    public class RandomIntDrawer
        : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            position.x += 15.0f*indent;
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            position.x -= 15.0f*indent;
            var rect = new Rect(position.x, position.y, position.width*0.45f, position.height);
            EditorGUI.PropertyField(rect, property.FindPropertyRelative("Base"), GUIContent.none);

            rect = new Rect(rect.x + rect.width, position.y, position.width*0.05f, position.height);
            EditorGUI.LabelField(rect, "~");

            rect = new Rect(rect.x + rect.width, position.y, position.width*0.5f, position.height);
            EditorGUI.PropertyField(rect, property.FindPropertyRelative("Mod"), GUIContent.none);

            EditorGUI.EndProperty();
            EditorGUI.indentLevel = indent;
        }
    }
}