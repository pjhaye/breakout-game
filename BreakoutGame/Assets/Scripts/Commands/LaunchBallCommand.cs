using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace BreakoutGame
{
    public class LaunchBallCommand : Command
    {
        private readonly BreakoutGameController _breakoutGameController;

        public LaunchBallCommand(BreakoutGameController breakoutGameController)
        {
            _breakoutGameController = breakoutGameController;
        }

        public override void Execute()
        {
            _breakoutGameController.LaunchBallInRandomDirection();            
            OnComplete();
        }
    }
}