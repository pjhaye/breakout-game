using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class DispatchDesireHudExitCommand : BreakoutGameCommand
    {
        public DispatchDesireHudExitCommand(BreakoutGameController breakoutGameController) :
            base(breakoutGameController)
        {

        }

        public override void Execute()
        {
            base.Execute();
            _breakoutGameController.DispatchDesireHudExit();
            OnComplete();
        }
    }
}