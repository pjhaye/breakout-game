using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class NextLevelPopupUi : InstantShowAndHideUi
    {
        [SerializeField]
        private LevelUi _levelUi;

        private BreakoutGameController _breakoutGameController;

        private void Awake()
        {
            HideUiInstant();
        }

        public void AssignBreakoutGameController(BreakoutGameController breakoutGameController)
        {
            _breakoutGameController = breakoutGameController;
            _breakoutGameController.BeatCurrentLevel += OnBeatCurrentLevel;
            _levelUi.LevelController = _breakoutGameController.LevelController;
        }

        private void OnBeatCurrentLevel()
        {
            ShowUi();
        }
    }
}