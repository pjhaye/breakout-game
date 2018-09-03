using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class InstantShowAndHideUi : AnimatedUi
    {
        public override void ShowUi()
        {
            base.ShowUi();
            gameObject.SetActive(true);
        }

        public override void ShowUiInstant()
        {
            base.ShowUiInstant();
            gameObject.SetActive(true);
        }

        public override void HideUi()
        {
            base.HideUi();
            gameObject.SetActive(false);
        }

        public override void HideUiInstant()
        {
            base.HideUiInstant();
            gameObject.SetActive(false);
        }
    }
}