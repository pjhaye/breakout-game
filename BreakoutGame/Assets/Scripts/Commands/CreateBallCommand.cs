using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace BreakoutGame
{
    public class CreateBallCommand: Command
    {
        private readonly BreakoutGameController _breakoutGameController;

        public CreateBallCommand(BreakoutGameController breakoutGameController)
        {
            _breakoutGameController = breakoutGameController;
        }

        public override void Execute()
        {
            _breakoutGameController.CreateBall();
            OnComplete();
        }
    }
}