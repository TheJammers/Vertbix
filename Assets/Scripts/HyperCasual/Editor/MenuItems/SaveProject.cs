using UnityEditor;
using UnityEngine;

namespace HyperCasual.Editor.MenuItems
{
    public static class SaveProject
    {
        [MenuItem(MenuName.Root + "Save Project" + MenuKey.Alt.S, false, 1)]
        public static void Perform()
        {
            Debug.Log("Saving");
            AssetDatabase.SaveAssets();
        }
    }
}
