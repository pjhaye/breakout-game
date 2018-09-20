using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class HudUi : InstantShowAndHideUi
    {
        [SerializeField]
        private LivesUi _livesUi;
        [SerializeField]
        private ScoreUi _scoreUi;
        [SerializeField]
        private LevelUi _levelUi;

        private BreakoutGameController _breakoutGameController;        

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

        private void Awake()
        {
            HideUiInstant();
        }

        public void AssignBreakoutGameController(BreakoutGameController breakoutGameController)
        {
            _breakoutGameController = breakoutGameController;
            _breakoutGameController.DesiredHudEnter += OnDesireEnter;
            _breakoutGameController.DesiredHudExit += OnDesireExit;
        }

        private void OnDesireEnter()
        {
            ShowUi();
        }

        private void OnDesireExit()
        {
            HideUi();
        }
    }
}