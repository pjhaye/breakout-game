using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class RestartGameCommand : Command
    {
        private BreakoutGameController _breakoutGameController;

        public RestartGameCommand(BreakoutGameController breakoutGameController)
        {
            _breakoutGameController = breakoutGameController;
        }

        public override void Execute()
        {
            base.Execute();
            _breakoutGameController.RestartGame();
            OnComplete();
        }
    }
}