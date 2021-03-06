﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class StartGameUi : InstantShowAndHideUi
    {
        private BreakoutGameController _breakoutGameController;

        private void Awake()
        {
            HideUiInstant();
        }

        public void OnPlayButtonClick()
        {
            if(!IsShowing)
            {
                return;
            }

            _breakoutGameController.StartGame();
            HideUi();
        }

        public void AssignBreakoutGameController
            (BreakoutGameController breakoutGameController)
        {
            _breakoutGameController = breakoutGameController;
            _breakoutGameController.DesiredStartGameScreen += OnRestartGame;
        }

        private void OnRestartGame()
        {
            ShowUi();
        }
    }
}