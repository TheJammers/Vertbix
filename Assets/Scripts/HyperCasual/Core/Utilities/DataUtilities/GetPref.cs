using UnityEngine;

namespace HyperCasual.Utilities
{
    /// <summary>
    /// Provides common get utilities wrapping Unity's PlayerPrefs operations.
    /// </summary>
    public static class GetPref
    {
        public static int Int(string key, int default_value = 0)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                Debug.LogWarningFormat("Missing Key::{0}\nDefault::{1}", key, default_value);
                PlayerPrefs.SetInt(key, default_value);
            }

            var value = PlayerPrefs.GetInt(key);
            Debug.LogFormat("Getting::{0}::{1}", key, value);

            return value;
        }

        public static float Float(string key, float default_value = 0)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                Debug.LogWarningFormat("Missing Key::{0}\nDefault::{1}", key, default_value);
                PlayerPrefs.SetFloat(key, default_value);
            }

            var value = PlayerPrefs.GetFloat(key);
            Debug.LogFormat("Getting::{0}::{1}", key, value);
            return value;
        }

        public static string String(string key, string default_value = "_")
        {
            if (!PlayerPrefs.HasKey(key))
            {
                Debug.LogWarningFormat("Missing Key::{0}\nDefault::{1}", key, default_value);
                PlayerPrefs.SetString(key, default_value);
            }

            var value = PlayerPrefs.GetString(key);
            Debug.LogFormat("Getting::{0}::{1}", key, value);
            return value;
        }

        public static bool Exists(string key)
        {
            return PlayerPrefs.HasKey(key);
        }
    }
}
