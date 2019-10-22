using UnityEngine;

namespace HyperCasual.Components
{
    public class ActivateOnIPhoneX
        : MonoBehaviour
    {
        public void Awake()
        {
            gameObject.SetActive(false);
#if UNITY_IOS
            switch (UnityEngine.iOS.Device.generation)
            {
                case UnityEngine.iOS.DeviceGeneration.iPhoneX:
                case UnityEngine.iOS.DeviceGeneration.iPhoneXS:
                case UnityEngine.iOS.DeviceGeneration.iPhoneXSMax:
                case UnityEngine.iOS.DeviceGeneration.iPhoneXR:
                    gameObject.SetActive(true);
                    break;

                default:
                    gameObject.SetActive(false);
                    break;
            }
#endif
        }
    }
}
