using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class DestroyBallCommand : BreakoutGameCommand
    {
        public DestroyBallCommand(BreakoutGameController breakoutGameController) :
            base(breakoutGameController)
        {

        }

        public override void Execute()
        {
            base.Execute();

            _breakoutGameController.DestroyBall();
            OnComplete();
        }
    }
}
