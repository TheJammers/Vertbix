using UnityEngine;

namespace HyperCasual.Extensions
{
    /// <summary>
    /// Extends the GameObject class with common transform operations.
    /// </summary>
    public static class EntityTransformExtensions
    {
        public static GameObject ResetLocal(this GameObject entity)
        {
            entity.transform.ResetLocal();
            return entity;
        }
    }
}
