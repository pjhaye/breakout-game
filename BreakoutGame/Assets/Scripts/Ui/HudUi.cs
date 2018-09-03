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
        [SerializeField]
        private LevelUi _levelUi;

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

        public LevelUi LevelUi
        {
            get
            {
                return _levelUi;
            }
        }
    }
}