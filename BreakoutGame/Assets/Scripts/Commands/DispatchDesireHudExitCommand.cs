using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class DispatchDesireHudExitCommand : Command
    {
        private BreakoutGameController _breakoutGameController;

        public DispatchDesireHudExitCommand(BreakoutGameController breakoutGameController)
        {
            _breakoutGameController = breakoutGameController;
        }

        public override void Execute()
        {
            base.Execute();
            _breakoutGameController.DispatchDesireHudExit();
            OnComplete();
        }
    }
}