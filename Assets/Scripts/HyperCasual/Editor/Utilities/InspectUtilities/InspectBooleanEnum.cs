using HyperCasual.Enums;
using UnityEditor;

namespace HyperCasual.Editor.Utilities
{
    public static class InspectBooleanEnum
    {
        public static bool Perform(string label, bool value)
        {
            var flag = value ? BooleanFlag.True : BooleanFlag.False;
            flag = (BooleanFlag) EditorGUILayout.EnumPopup(label, flag);
            return flag == BooleanFlag.True;
        }
    }
}
