using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class ResetGameCommand : BreakoutGameCommand
    {
        public ResetGameCommand(BreakoutGameController breakoutGameController) :
            base(breakoutGameController)
        {

        }

        public override void Execute()
        {
            base.Execute();
            _breakoutGameController.ResetGame();
            OnComplete();
        }
    }
}