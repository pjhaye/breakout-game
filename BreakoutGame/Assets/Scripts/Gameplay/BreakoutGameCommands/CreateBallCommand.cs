using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace BreakoutGame
{
    public class CreateBallCommand: BreakoutGameCommand
    {
        public CreateBallCommand(BreakoutGameController breakoutGameController) :
            base(breakoutGameController)
        {

        }

        public override void Execute()
        {
            _breakoutGameController.CreateBall();
            OnComplete();
        }
    }
}