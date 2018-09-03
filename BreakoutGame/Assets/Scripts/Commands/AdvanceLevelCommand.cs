using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class AdvanceLevelCommand : Command
    {
        private readonly BreakoutGameController _breakoutGameController;

        public AdvanceLevelCommand(BreakoutGameController breakoutGameController)
        {
            _breakoutGameController = breakoutGameController;
        }

        public override void Execute()
        {
            base.Execute();

            _breakoutGameController.AdvanceLevel();
            OnComplete();
        }
    }
}