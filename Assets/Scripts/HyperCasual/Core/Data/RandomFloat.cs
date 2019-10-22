using System;

namespace HyperCasual.Data
{
    /// <summary>
    /// Allows users to easily generate a random float value from a given base and some interval.
    /// </summary>
    [Serializable]
    public struct RandomFloat
    {
        public float Base;
        public Interval Mod;

        public float GetRandom()
        {
            return Base + Mod.GetRandom();
        }

        public RandomFloat(float base_value, float mod_range)
        {
            Base = base_value;
            Mod = new Interval(-mod_range, +mod_range);
        }

        public RandomFloat(float base_value, Interval mod_range)
        {
            Base = base_value;
            Mod = mod_range;
        }
    }
}
