using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class AdvanceLevelCommand : BreakoutGameCommand
    {
        public AdvanceLevelCommand(BreakoutGameController breakoutGameController) :
            base(breakoutGameController)
        {

        }

        public override void Execute()
        {
            base.Execute();

            _breakoutGameController.AdvanceLevel();
            OnComplete();
        }
    }
}