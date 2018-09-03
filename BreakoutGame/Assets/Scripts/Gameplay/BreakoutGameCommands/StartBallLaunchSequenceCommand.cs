using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace BreakoutGame
{
    public class StartBallLaunchSequenceCommand: BreakoutGameCommand
    {
        public StartBallLaunchSequenceCommand(BreakoutGameController breakoutGameController) :
            base(breakoutGameController)
        {

        }

        public override void Execute()
        {
            _breakoutGameController.StartBallLaunchSequence();
            OnComplete();
        }
    }
}