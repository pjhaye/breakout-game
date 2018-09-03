using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace BreakoutGame
{
    public class LaunchBallCommand : BreakoutGameCommand
    {
        public LaunchBallCommand(BreakoutGameController breakoutGameController) :
            base(breakoutGameController)
        {

        }

        public override void Execute()
        {
            _breakoutGameController.LaunchBall();           
            OnComplete();
        }
    }
}