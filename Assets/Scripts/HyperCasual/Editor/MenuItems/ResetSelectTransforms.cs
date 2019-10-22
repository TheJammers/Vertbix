using HyperCasual.Extensions;
using UnityEditor;
using UnityEngine;

namespace HyperCasual.Editor.MenuItems
{
    /// <summary>
    /// Provides a menu action item for resetting all selected transforms in the scene.
    /// </summary>
    public static class ResetSelectTransforms
    {
        [MenuItem(MenuName.SceneMenu + "Reset Selected Transforms" + MenuKey.Alt.Z)]
        public static void Perform()
        {
            foreach (var selected in Selection.gameObjects)
            {
                Undo.RecordObject(selected.transform, selected.name + "_Reset");
                selected.transform.ResetLocal();
                
                var rect_transform = selected.GetComponent<RectTransform>();
                if (rect_transform != null)
                    rect_transform.ResetLocalRect();

                EditorUtility.SetDirty(selected);
            }
        }
    }
}