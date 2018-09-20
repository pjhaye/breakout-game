using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class DispatchBeatCurrentLevelCommand : BreakoutGameCommand
    {
        public DispatchBeatCurrentLevelCommand(BreakoutGameController breakoutGameController) :
            base(breakoutGameController)
        {

        }

        public override void Execute()
        {
            base.Execute();
            _breakoutGameController.DispatchBeatCurrentLevel();
            OnComplete();
        }
    }
}