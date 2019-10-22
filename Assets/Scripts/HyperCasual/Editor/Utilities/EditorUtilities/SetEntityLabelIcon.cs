using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace HyperCasual.Editor.Utilities
{
    /// <summary>
    /// Provides a simplified way for setting in-editor GameObject icons via code.
    /// </summary>
    public static class SetEntityLabelIcon
    {
        public const string MethodName = "SetIconForObject";
        public static readonly BindingFlags Flags = BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.NonPublic;

        public static GameObject Perform(GameObject target, int icon_index)
        {
            var icons = GenerateIconList();
            var icon = icons[icon_index];
            var args = new object[] { target, icon.image };

            var gui_utility = typeof(EditorGUIUtility);
            var arg_types = new[] { typeof(Object), typeof(Texture2D) };
            var set_icon = gui_utility.GetMethod(MethodName, Flags, null, arg_types, null);
            set_icon.Invoke(null, args);

            return target;
        }

        private static GUIContent[] GenerateIconList()
        {
            const int count = 8;
            var content = new GUIContent[count];
            for (var i = 0; i < count; ++i)
                content[i] = EditorGUIUtility.IconContent(string.Format("sv_label_{0}", i));

            return content;
        }
    }
}