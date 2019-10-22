using UnityEditor;

namespace HyperCasual.Editor.MenuItems
{
    /// <summary>
    /// Provides a menu item for toggling the active state of selected entities.
    /// </summary>
    public static class ToggleSelectEntities
    {
        [MenuItem(MenuName.SceneMenu + "Toggle Selected Entities" + MenuKey.Alt.A)]
        public static void Perform()
        {
            foreach (var selected in Selection.gameObjects)
                selected.SetActive(!selected.activeSelf);
        }
    }
}
