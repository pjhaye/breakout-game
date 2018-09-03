using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class RestartGameCommand : BreakoutGameCommand
    {
        public RestartGameCommand(BreakoutGameController breakoutGameController) :
            base(breakoutGameController)
        {

        }

        public override void Execute()
        {
            base.Execute();
            _breakoutGameController.RestartGame();
            OnComplete();
        }
    }
}