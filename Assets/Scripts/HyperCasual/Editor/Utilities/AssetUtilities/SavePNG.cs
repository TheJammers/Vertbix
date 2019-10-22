using System.IO;
using UnityEditor;
using UnityEngine;

namespace HyperCasual.Editor.Utilities
{
    /// <summary>
    /// Responsible for saving the given texture2D instance as a PNG.
    /// </summary>
    public static class SavePNG
    {
        public static Texture2D Perform(Texture2D texture, string relative_path)
        {
            var bytes = texture.EncodeToPNG();
            File.WriteAllBytes(relative_path, bytes);

            AssetDatabase.ImportAsset(relative_path);
            return AssetDatabase.LoadAssetAtPath<Texture2D>(relative_path);
        }
    }
}