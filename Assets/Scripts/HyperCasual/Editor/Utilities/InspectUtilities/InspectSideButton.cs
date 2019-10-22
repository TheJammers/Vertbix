using UnityEngine;

namespace HyperCasual.Editor.Utilities
{
    /// <summary>
    /// Provides small buttons for use with custom field inspection.s
    /// </summary>
    public static class InspectSideButton
    {
        public static bool Plus() { return Perform("+"); }
        public static bool Minus() { return Perform("-"); }
        public static bool Star() { return Perform("*"); }
        public static bool Pound() { return Perform("#"); }
        public static bool Tilde() { return Perform("~"); }
        public static bool Exclamation() { return Perform("!"); }
        public static bool Up() { return Perform("⮝"); }
        public static bool Down() { return Perform("⮟"); }
        public static bool Left() { return Perform("⮜"); }
        public static bool Right() { return Perform("⮞"); }

        public static bool Perform(string label)
        {
            return GUILayout.Button(label, GUILayout.Width(19.0f), GUILayout.Height(13.5f));
        }
    }
}
