using System;

namespace HyperCasual.Data
{
    /// <summary>
    /// Describes a floating point interval between a minimum and maximum values.
    /// </summary>
    [Serializable]
    public struct Interval
    {
        public float Min;
        public float Max;

        public bool Contains(float value)
        {
            return Min <= value && value <= Max;
        }

        public float GetRandom()
        {
            return UnityEngine.Random.Range(Min, Max);
        }

        public float GetLocked(float value)
        {
            return value < Min ? Min : value > Max ? Max : value;
        }

        public Interval(float min, float max)
        {
            Min = min;
            Max = max;
        }
    }
}
