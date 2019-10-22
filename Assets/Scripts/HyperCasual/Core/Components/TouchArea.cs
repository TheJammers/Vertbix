using System;
using HyperCasual.Data;
using HyperCasual.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HyperCasual.Components
{
    using PointerArgs = ValueArgs<PointerEventData>;

    public class TouchArea
        : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event EventHandler<PointerArgs> Touched;
        public event EventHandler<PointerArgs> Released;
        public bool IsTouching { get; private set; }

        public void OnPointerDown(PointerEventData event_data)
        {
            IsTouching = true;
            this.Raise(Touched, new PointerArgs(event_data));
        }

        public void OnPointerUp(PointerEventData event_data)
        {
            IsTouching = false;
            this.Raise(Released, new PointerArgs(event_data));
        }
    }
}
