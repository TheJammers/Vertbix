using System;
using UnityEngine;

namespace HyperCasual.Data
{
    /// <summary>
    /// Allows users to easily generate a random vector3 from three random floats.
    /// </summary>
    [Serializable]
    public struct RandomVector3
    {
        public RandomFloat X;
        public RandomFloat Y;
        public RandomFloat Z;

        public Vector3 GetRandom()
        {
            return new Vector3(X.GetRandom(), Y.GetRandom(), Z.GetRandom());
        }
    }
}
