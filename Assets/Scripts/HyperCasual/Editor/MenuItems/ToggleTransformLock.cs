using HyperCasual.Editing.Components;
using HyperCasual.Editor.Extensions;
using UnityEditor;

namespace HyperCasual.Editor.MenuItems
{
    public static class ToggleTransformLock
    {
        [MenuItem(MenuName.SceneMenu + "Add Transform Lock" + MenuKey.Alt.X)]
        public static void AddLocks()
        {
            foreach (var selected in Selection.gameObjects)
            {
                var position_lock = selected.GetComponent<PositionLock>();
                if (position_lock == null)
                    selected.AddComponent<PositionLock>().UpdateCached();

                var rotation_lock = selected.GetComponent<RotationLock>();
                if (rotation_lock == null)
                    selected.AddComponent<RotationLock>().UpdateCached();
                
                var scale_lock = selected.GetComponent<ScaleLock>();
                if (scale_lock == null)
                    selected.AddComponent<ScaleLock>().UpdateCached();
            }
        }

        [MenuItem(MenuName.SceneMenu + "Remove Transform Lock")]
        public static void RemoveLocks()
        {
            foreach (var selected in Selection.gameObjects)
            {
                selected.EditorRemoveComponent<PositionLock>();
                selected.EditorRemoveComponent<RotationLock>();
                selected.EditorRemoveComponent<ScaleLock>();
            }
        }
    }
}
