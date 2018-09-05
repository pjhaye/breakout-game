using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class GameOverUi : InstantShowAndHideUi
    {
        [SerializeField]
        private ScoreUi _scoreUi;

        private BreakoutGameController _breakoutGameController;        

        public ScoreUi ScoreUi
        {
            get
            {
                return _scoreUi;
            }
        }

        private void Awake()
        {
            HideUiInstant();
        }

        public void AssignBreakoutGameController(
            BreakoutGameController breakoutGameController)
        {
            _breakoutGameController = breakoutGameController;
            _scoreUi.ScoreController = breakoutGameController.ScoreController;
            _breakoutGameController.ReachedGameOver += OnReachedGameOver;
        }

        public void OnReachedGameOver()
        {
            ShowUi();
        }

        public void OnTryAgainButtonClick()
        {
            if (!IsShowing)
            {
                return;
            }

            _breakoutGameController.StartResetGameSequence();
            HideUi();
        }
    }
}