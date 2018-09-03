using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class HudUi : MonoBehaviour
    {
        [SerializeField]
        private LivesUi _livesUi;

        public LivesUi LivesUi
        {
            get
            {
                return _livesUi;
            }
        }
    }
}