using System.Collections.Generic;
using UnityEngine;

namespace HyperCasual.Components
{
    public delegate void SimpleMethod();

    /// <summary>
    /// Responsible for invoking stored methods after a given amount of time.
    /// </summary>
    public class TimedInvoke
        : MonoBehaviour
    {
        public float TimeLeft;

        public void Awake()
        {
            _callbacks = new List<SimpleMethod>();
        }

        public TimedInvoke Call(SimpleMethod callback)
        {
            _callbacks.Add(callback);
            return this;
        }

        public TimedInvoke Prime(float value)
        {
            TimeLeft = value;
            return this;
        }

        public void Update()
        {
            TimeLeft -= Time.deltaTime;
            if (TimeLeft > 0.0f)
                return;

            foreach (var callback in _callbacks)
                callback();

            enabled = false;
        }

        private List<SimpleMethod> _callbacks;
    }
}
