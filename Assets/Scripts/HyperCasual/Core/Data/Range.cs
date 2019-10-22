using System;

namespace HyperCasual.Data
{
    /// <summary>
    /// Describes an integer range between a minimum and maximum values.
    /// </summary>
    [Serializable]
    public struct Range
    {
        public int Min;
        public int Max;

        public bool Contains(int value)
        {
            return Min <= value && value <= Max;
        }

        public int GetRandom()
        {
            return UnityEngine.Random.Range(Min, Max);
        }

        public float GetLocked(int value)
        {
            return value < Min ? Min : value > Max ? Max : value;
        }

        public Range(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}
