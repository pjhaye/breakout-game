using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class StateMachine<T>
    {
        private State<T> _state;

        public State<T> State
        {
            get
            {
                return _state;
            }
            set
            {
                if (_state != null)
                {
                    _state.OnExit();
                }
                _state = value;
                if (_state != null)
                {
                    _state.OnEnter();
                }
            }
        }

        protected StateMachine()
        {

        }

        public void Update(float deltaTime)
        {
            if(State != null)
            {
                State.OnUpdate(deltaTime);
            }
        }

        public void FixedUpdate(float deltaTime)
        {
            if(State != null)
            {
                State.OnFixedUpdate(deltaTime);
            }
        }

        public void LateUpdate(float deltaTime)
        {
            if(State != null)
            {
                State.OnLateUpdate(deltaTime);
            }
        }        
    }
}