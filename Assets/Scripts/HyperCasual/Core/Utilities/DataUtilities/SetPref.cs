using UnityEngine;

namespace HyperCasual.Utilities
{
    /// <summary>
    /// Provides common set utilities wrapping Unity's PlayerPrefs operations.
    /// </summary>
    public static class SetPref
    {
        public static int Int(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
            return value;
        }

        public static float Float(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
            return value;
        }

        public static string String(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
            return value;
        }
    }
}
