using UnityEngine;
using UnityEngine.UI;

namespace HyperCasual.Components
{
    /// <summary>
    /// Responsible for opening a given URL on owning button click.
    /// </summary>
    public class OnClickOpenURL
        : MonoBehaviour
    {
        public string Address;

        public void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OpenBrowser);
        }

        private void OpenBrowser()
        {
            Application.OpenURL(Address);
        }
    }
}
