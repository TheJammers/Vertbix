using System;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownRace
{
    public class Segment : MonoBehaviour
    {
        public List<Transform> joints = null;

        private void Awake()
        {
            Populate();
        }

        public void Populate()
        {
            joints = new List<Transform>();
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                if (child.CompareTag("Joint"))
                {
                    joints.Add(child);
                }
            }
        }
    }
}