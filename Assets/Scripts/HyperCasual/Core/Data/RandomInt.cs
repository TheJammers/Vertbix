using System;

namespace HyperCasual.Data
{
    /// <summary>
    /// Allows users to easily generate a random integer value from a given base and some range.
    /// </summary>
    [Serializable]
    public struct RandomInt
    {
        public int Base;
        public Range Mod;

        public int GetRandom()
        {
            return Base + Mod.GetRandom();
        }

        public RandomInt(int base_value, int mod_range)
        {
            Base = base_value;
            Mod = new Range(-mod_range, +mod_range);
        }

        public RandomInt(int base_value, Range mod_range)
        {
            Base = base_value;
            Mod = mod_range;
        }
    }
}
