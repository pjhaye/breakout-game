using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class RemoveLifeCommand : Command
    {
        private BreakoutGameController _breakoutGameController;

        public RemoveLifeCommand(BreakoutGameController breakoutGameController)
        {
            _breakoutGameController = breakoutGameController;
        }

        public override void Execute()
        {
            base.Execute();

            _breakoutGameController.RemoveLife();
            OnComplete();
        }
    }
}