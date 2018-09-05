using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BreakoutGame
{
    public class InstantShowAndHideUi : AnimatedUi
    {
        [SerializeField]
        private bool _waitForChildrenToHide = true;

        private List<AnimatedUi> _childrenToWaitFor = new List<AnimatedUi>();

        public override void ShowUi()
        {
            base.ShowUi();
            gameObject.SetActive(true);          
            OnShowUiComplete();
        }

        public override void ShowUiInstant()
        {
            base.ShowUiInstant();
            gameObject.SetActive(true);
            OnShowUiComplete();
        }

        public override void HideUi()
        {
            base.HideUi();

            if (_waitForChildrenToHide)
            {
                _childrenToWaitFor = GetComponentsInChildren<AnimatedUi>(true).ToList();
                _childrenToWaitFor.Remove(this);
            }
            else
            {
                HideUiInstant();
            }
        }

        private void Update()
        {
            if (IsExiting)
            {
                var allChildrenHidden = true;
                foreach (var child in _childrenToWaitFor)
                {
                    if(child.IsExiting)
                    {
                        allChildrenHidden = false;
                    }
                }
                if(allChildrenHidden)
                {
                    HideUiInstant();
                }
            }
        }

        public override void HideUiInstant()
        {
            base.HideUiInstant();
            gameObject.SetActive(false);
            OnHideUiComplete();
        }
    }
}