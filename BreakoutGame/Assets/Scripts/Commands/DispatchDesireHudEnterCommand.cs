using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class DispatchDesireHudEnterCommand : Command
    {
        private BreakoutGameController _breakoutGameController;

        public DispatchDesireHudEnterCommand(BreakoutGameController breakoutGameController)
        {
            _breakoutGameController = breakoutGameController;
        }

        public override void Execute()
        {
            base.Execute();
            _breakoutGameController.DispatchDesireHudEnter();
            OnComplete();
        }
    }
}