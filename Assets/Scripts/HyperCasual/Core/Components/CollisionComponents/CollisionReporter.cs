using System;
using HyperCasual.Data;
using HyperCasual.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HyperCasual
{
    using CollisionArgs = ValueArgs<Collision>;

    /// <summary>
    /// Responsible for reporting back using events on collisions.
    /// </summary>
    public class CollisionReporter
        : MonoBehaviour
    {
        protected event EventHandler<CollisionArgs> CollisionEnter;
        protected event EventHandler<CollisionArgs> CollisionExit;

        protected event EventHandler MouseEnter;
        protected event EventHandler MouseExit;
        protected event EventHandler MouseDown;
        protected event EventHandler MouseUp;
        protected event EventHandler MouseOver;

        void OnCollisionEnter(Collision data)
        {
            this.Raise(CollisionEnter, new CollisionArgs(data));
        }

        void OnCollisionExit(Collision data)
        {
            this.Raise(CollisionExit, new CollisionArgs(data));
        }
        
        private void OnMouseEnter()
        {
            this.Raise(MouseEnter);
        }
        
        
        private void OnMouseExit()
        {
            this.Raise(MouseExit);
        }
        
        public void OnMouseDown()
        {
            if (!EventSystem.current.IsPointerOverGameObject() && EventSystem.current.currentSelectedGameObject == null)
            {
                this.Raise(MouseDown);
            }
        }

        private void OnMouseUp()
        {
            this.Raise(MouseUp);
        }

        private void OnMouseOver()
        {
            this.Raise(MouseOver);
        }
        

        public CollisionReporter SubscribeToOnCollisionEnter(EventHandler<CollisionArgs> handler)
        {
            CollisionEnter += handler;
            return this;
        }

        public CollisionReporter SubscribeToOnCollisionExit(EventHandler<CollisionArgs> handler)
        {
            CollisionExit += handler;
            return this;
        }

        public CollisionReporter UnsubscribeToOnCollisionEnter(EventHandler<CollisionArgs> handler)
        {
            CollisionEnter -= handler;
            return this;
        }

        public CollisionReporter UnsubscribeToOnCollisionExit(EventHandler<CollisionArgs> handler)
        {
            CollisionExit -= handler;
            return this;
        }
        
        public CollisionReporter SubscribeToOnMouseDown(EventHandler mouseHandler)
        {
            MouseDown += mouseHandler;
            return this;
        }

        public CollisionReporter UnsubscribeToOnMouseDown(EventHandler mouseHandler)
        {
            MouseDown -= mouseHandler;
            return this;
        }
        
        public CollisionReporter SubscribeToOnMouseUp(EventHandler mouseHandler)
        {
            MouseUp += mouseHandler;
            return this;
        }

        public CollisionReporter UnsubscribeToOnMouseUp(EventHandler mouseHandler)
        {
            MouseUp -= mouseHandler;
            return this;
        }

        public CollisionReporter SubscribeToOnMouseEnter(EventHandler mouseHandler)
        {
            MouseEnter += mouseHandler;
            return this;
        }

        public CollisionReporter UnsubscribeToOnMouseEnter(EventHandler mouseHandler)
        {
            MouseEnter -= mouseHandler;
            return this;
        }

        public CollisionReporter SubscribeToOnMouseExit(EventHandler mouseHandler)
        {
            MouseExit += mouseHandler;
            return this;
        }

        public CollisionReporter UnsubscribeToOnMouseExit(EventHandler mouseHandler)
        {
            MouseExit -= mouseHandler;
            return this;
        }

        public CollisionReporter SubscribeToOnMouseOver(EventHandler mouseHandler)
        {
            MouseOver += mouseHandler;
            return this;
        }

        public CollisionReporter UnsubscribeToOnMouseOver(EventHandler mouseHandler)
        {
            MouseOver -= mouseHandler;
            return this;
        }
        
    }
}
