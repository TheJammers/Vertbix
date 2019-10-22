using UnityEditor;
using UnityEngine;

namespace HyperCasual.Editor.Utilities
{
    /// <summary>
    /// Provides inspection of custom toggle side buttons.
    /// </summary>
    public static class InspectToggleButton
    {
        public static bool Plus(bool value) { return Perform("+", value); }
        public static bool Minus(bool value) { return Perform("-", value); }
        public static bool Star(bool value) { return Perform("*", value); }
        public static bool Pound(bool value) { return Perform("#", value); }
        public static bool Tilde(bool value) { return Perform("~", value); }
        public static bool Exclamation(bool value) { return Perform("!", value); }
        public static bool Up(bool value) { return Perform("⮝", value); }
        public static bool Down(bool value) { return Perform("⮟", value); }
        public static bool Left(bool value) { return Perform("⮜", value); }
        public static bool Right(bool value) { return Perform("⮞", value); }

        public static bool Perform(string label, bool value)
        {
            return GUILayout.Toggle(value, label, "Button", GUILayout.Width(20.0f), GUILayout.Height(15.0f));
        }
    }
}
