using UnityEngine;
using System;

namespace TopDownRace
{
    public class Level : MonoBehaviour
    {
        public Segment start = null;
        public Segment end = null;
        public Transform startPos = null;

        public event Action<GameObject> CharacterFinished;

        void Start()
        {
        }
    }
}