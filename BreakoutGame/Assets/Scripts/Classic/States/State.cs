using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class State<T>
    {
        private readonly T _context;

        public T Context
        {
            get
            {
                return _context;
            }
        }

        protected State(T context)
        {
            _context = context;
        }

        public virtual void OnEnter()
        {

        }

        public virtual void OnExit()
        {

        }

        public virtual void OnUpdate(float deltaTime)
        {

        }

        public virtual void OnFixedUpdate(float deltaTime)
        {

        }

        public virtual void OnLateUpdate(float deltaTime)
        {

        }                
    }
}
