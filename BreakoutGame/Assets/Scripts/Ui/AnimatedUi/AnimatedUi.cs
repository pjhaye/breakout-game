using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class AnimatedUi : 
        MonoBehaviour, 
        IShowableUi, 
        IHideableUi
    {
        private AnimatedUiState _state = AnimatedUiState.Showing;
        public AnimatedUiState State
        {
            get
            {
                return _state;
            }
        }

        public bool IsShowing
        {
            get
            {
                return _state == AnimatedUiState.Showing;
            }
        }

        public bool IsHidden
        {
            get
            {
                return _state == AnimatedUiState.Hidden;
            }
        }

        public bool IsEntering
        {
            get
            {
                return _state == AnimatedUiState.Entering;
            }
        }

        public bool IsExiting
        {
            get
            {
                return _state == AnimatedUiState.Exiting;
            }
        }

        public virtual void ShowUi()
        {
            if(IsShowing)
            {
                return;
            }

            enabled = true;
            var children = GetComponentsInChildren<AnimatedUi>(true);
            foreach(var child in children)
            {
                if(child.gameObject == gameObject)
                {
                    continue;
                }
                child.ShowUi();
            }
            _state = AnimatedUiState.Entering;
        }

        protected void OnShowUiComplete()
        {
            _state = AnimatedUiState.Showing;
        }

        public virtual void ShowUiInstant()
        {
            if(IsShowing)
            {
                return;
            }

            enabled = true;
            var children = GetComponentsInChildren<AnimatedUi>(true);
            foreach (var child in children)
            {
                if (child.gameObject == gameObject)
                {
                    continue;
                }
                child.ShowUiInstant();
            }

            _state = AnimatedUiState.Showing;
        }

        public virtual void HideUi()
        {
            if(IsHidden)
            {
                return;
            }

            var children = GetComponentsInChildren<AnimatedUi>(true);
            foreach (var child in children)
            {
                if (child.gameObject == gameObject)
                {
                    continue;
                }
                child.HideUi();
            }

            _state = AnimatedUiState.Exiting;
        }

        protected void OnHideUiComplete()
        {
            _state = AnimatedUiState.Hidden;
        }

        public virtual void HideUiInstant()
        {
            if(IsHidden)
            {
                return;
            }

            var children = GetComponentsInChildren<AnimatedUi>(true);
            foreach (var child in children)
            {
                if (child.gameObject == gameObject)
                {
                    continue;
                }
                child.HideUiInstant();
            }

            _state = AnimatedUiState.Hidden;
        }
    }
}