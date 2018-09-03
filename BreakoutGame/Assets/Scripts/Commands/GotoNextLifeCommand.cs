using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class GotoNextLifeCommand : Command
    {
        private BreakoutGameController _breakoutGameController;

        public GotoNextLifeCommand(BreakoutGameController breakoutGameController)
        {
            _breakoutGameController = breakoutGameController;
        }

        public override void Execute()
        {
            base.Execute();

            _breakoutGameController.GotoNextLife();
            OnComplete();
        }
    }
}