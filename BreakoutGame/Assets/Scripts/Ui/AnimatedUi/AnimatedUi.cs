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
        public virtual void ShowUi()
        {
            var children = GetComponentsInChildren<AnimatedUi>(true);
            foreach(var child in children)
            {
                if(child == this)
                {
                    continue;
                }
                child.ShowUi();
            }
        }

        public virtual void ShowUiInstant()
        {
            var children = GetComponentsInChildren<AnimatedUi>(true);
            foreach (var child in children)
            {
                if (child == this)
                {
                    continue;
                }
                child.ShowUiInstant();
            }
        }

        public virtual void HideUi()
        {
            var children = GetComponentsInChildren<AnimatedUi>(true);
            foreach (var child in children)
            {
                if (child == this)
                {
                    continue;
                }
                child.HideUi();
            }
        }

        public virtual void HideUiInstant()
        {
            var children = GetComponentsInChildren<AnimatedUi>(true);
            foreach (var child in children)
            {
                if (child == this)
                {
                    continue;
                }
                child.HideUiInstant();
            }
        }
    }
}