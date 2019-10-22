using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace HyperCasual.Editor.MenuItems
{
    /// <summary>
    /// Provides a menu item for creating new empty scenes.
    /// </summary>
    public static class CreateEmptyScene
    {
        [MenuItem(MenuName.SceneMenu + "Create Empty Scene" + MenuKey.CtrlAlt.N)]
        public static void Perform()
        {
            var confirmed = EditorUtility.DisplayDialog("Scene", "Create An Empty Scene?", "Yes", "No");
            if (!confirmed)
                return;
            
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            RenderSettings.skybox = null;
        }
    }
}