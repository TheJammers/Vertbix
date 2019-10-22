using System.Collections.Generic;
using UnityEngine;

namespace HyperCasual.Extensions
{
    /// <summary>
    /// Extends a list of entities with activation operations.
    /// </summary>
    public static class EntityListActiveExtensions
    {
        public static List<GameObject> ToggleActiveState(this List<GameObject> list)
        {
            for (var i = 0; i < list.Count; ++i)
                list[i].SetActiveState(!list[i].activeSelf);

            return list;
        }

        public static List<GameObject> SetActiveState(this List<GameObject> list, bool value)
        {
            for (var i = 0; i < list.Count; ++i)
                list[i].SetActiveState(value);

            return list;
        }

        public static List<GameObject> Deactivate(this List<GameObject> list, int index)
        {
            list[index].SetActiveState(false);
            return list;
        }

        public static List<GameObject> Activate(this List<GameObject> list, int index)
        {
            list[index].SetActiveState(true);
            return list;
        }

        public static List<GameObject> DeactivateAll(this List<GameObject> list)
        {
            for (var i = 0; i < list.Count; ++i)
                list[i].SetActiveState(false);

            return list;
        }

        public static List<GameObject> ActivateAll(this List<GameObject> list)
        {
            for (var i = 0; i < list.Count; ++i)
                list[i].SetActiveState(true);

            return list;
        }
    }
}
