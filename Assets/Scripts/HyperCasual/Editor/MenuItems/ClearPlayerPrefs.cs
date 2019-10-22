using UnityEditor;
using UnityEngine;

namespace HyperCasual.Editor.MenuItems
{
    /// <summary>
    /// Provides a menu action for clearing Unity's saved player prefs.
    /// </summary>
    public static class ClearPlayerPrefs
    {
        [MenuItem(MenuName.Root + "Clear PlayerPrefs" + MenuKey.Alt.Zero, false, 0)]
        public static void Perform()
        {
            var confirmed = EditorUtility.DisplayDialog("Clear Prefs", "Are you sure you want to clear the player prefs?", "Yes", "No");
            if (confirmed)
                PlayerPrefs.DeleteAll();
        }
    }
}
