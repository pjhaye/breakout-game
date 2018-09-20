using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class DispatchReachedGameOverCommand : BreakoutGameCommand
    {
        public DispatchReachedGameOverCommand(BreakoutGameController breakoutGameController) :
            base(breakoutGameController)
        {

        }

        public override void Execute()
        {
            base.Execute();
            _breakoutGameController.DispatchReachedGameOver();
            OnComplete();
        }
    }
}