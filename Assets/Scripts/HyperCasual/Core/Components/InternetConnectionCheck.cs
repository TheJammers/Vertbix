using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

namespace HyperCasual
{
    /// <summary>
    /// Responsible for checking whether the application is currently connected to the internet.
    /// </summary>
    public class InternetConnectionCheck
        : MonoBehaviour
    {
        public float TestFrequency = 5.0f; //in seconds
        public string TargetURL = "https://ping.ttpsdk.info/TabTale-Test";
        public bool InitializeSelf;
        public bool Connected;

        public UnityEvent ConnectionMade;
        public UnityEvent ConnectionBroken;
        public bool Initialized { get; private set; }
        public bool Active { get; private set; }

        public void Awake()
        {
            Active = true;
            Connected = false;
            if (InitializeSelf)
                Initialize();
        }

        public InternetConnectionCheck Initialize()
        {
            if (Initialized)
                throw new InvalidOperationException("InternetConnectionCheck::Already initialized!");

            Initialized = true;
            StartCoroutine(PerformConnectionCheck());

            return this;
        }

        private IEnumerator PerformConnectionCheck()
        {
            yield return null;

            while (Active)
            {
                var www = new UnityWebRequest(GenerateRandomURL());
                yield return www;

                var connected = www.isDone && www.downloadedBytes > 0;
                if (connected && !Connected)
                    ConnectionMade.Invoke();

                if (!connected && Connected)
                    ConnectionBroken.Invoke();

                Connected = connected;
                yield return new WaitForSecondsRealtime(TestFrequency);
            }
        }

        private string GenerateRandomURL()
        {
            var random_string = Random.Range(1, 100000000).ToString();
            return TargetURL + "?p=" + random_string;
        }
    }
}