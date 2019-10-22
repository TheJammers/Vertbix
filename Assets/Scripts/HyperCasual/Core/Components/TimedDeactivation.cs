using UnityEngine;

namespace HyperCasual.Components
{
    /// <summary>
    /// Responsible for deactivating its owning entity after a given amount of time.
    /// </summary>
    public class TimedDeactivation
        : MonoBehaviour
    {
        public float TimeLeft;

        public TimedDeactivation Prime(float value)
        {
            TimeLeft = value;
            return this;
        }

        public void Update()
        {
            TimeLeft -= Time.deltaTime;
            if (TimeLeft > 0.0f)
                return;

            gameObject.SetActive(false);
        }
    }
}
