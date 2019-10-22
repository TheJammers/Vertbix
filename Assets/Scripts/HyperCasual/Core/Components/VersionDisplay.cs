using UnityEngine;
using UnityEngine.UI;

namespace HyperCasual.Components
{
    /// <summary>
    /// Responsible for displaying the game's current version.
    /// </summary>
    public class VersionDisplay
        : MonoBehaviour
    {
        public Text Display;

        public void Start()
        {
            Display.text = string.Format("v{0}", Application.version);
        }
    }
}
