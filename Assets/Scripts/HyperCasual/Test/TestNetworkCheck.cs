using UnityEngine;
using UnityEngine.UI;

namespace HyperCasual.Test
{
    /// <summary>
    /// Provides an example of the internet check component.
    /// </summary>
    public class TestNetworkCheck
        : MonoBehaviour
    {
        public Text Output;

        public void ShowChecking()
        {
            Output.text = "Checking...";
        }

        public void ShowConnected()
        {
            Output.text = "Connected";
        }

        public void ShowDisconnected()
        {
            Output.text = "Disconnected";
        }
    }
}
