using UnityEngine;
using UnityEngine.UI;

namespace HyperCasual
{
    /// <summary>
    /// Responsible for counting and displaying the current framerate (FPS and SPF) to a target text component.
    /// </summary>
    public class FramerateDisplay
        : MonoBehaviour
    {
        [Tooltip("If null on awake will attempt to get text component from owner")]
        public Text Display;

        public void Awake()
        {
            Display = Display ?? GetComponent<Text>();
        }

        public void Update()
        {
            _accumulated += (Time.unscaledDeltaTime - _accumulated)*0.1f;
        }

        public void LateUpdate()  
        {
            var ms = _accumulated*1000.0f;
            var fps = 1.0f/_accumulated;
            Display.text = string.Format("{1:0.}fps\n[{0:0.0}ms]", ms, fps);
        }

        private float _accumulated;
    }
}