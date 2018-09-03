using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class HudUi : MonoBehaviour
    {
        [SerializeField]
        private LivesUi _livesUi;
        [SerializeField]
        private ScoreUi _scoreUi;

        public LivesUi LivesUi
        {
            get
            {
                return _livesUi;
            }
        }

        public ScoreUi ScoreUi
        {
            get
            {
                return _scoreUi;
            }
        }
    }
}