using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace BreakoutGame
{
    public class StartBallLaunchSequenceCommand: Command
    {
        private readonly BreakoutGameController _breakoutGameController;

        public StartBallLaunchSequenceCommand(BreakoutGameController breakoutGameController)
        {
            _breakoutGameController = breakoutGameController;
        }

        public override void Execute()
        {
            _breakoutGameController.StartBallLaunchSequence();
            OnComplete();
        }
    }
}