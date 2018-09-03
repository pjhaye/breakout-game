using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class DestroyBallCommand : Command
    {
        private readonly BreakoutGameController _breakoutGameController;

        public DestroyBallCommand(BreakoutGameController breakoutGameController)
        {
            _breakoutGameController = breakoutGameController;
        }

        public override void Execute()
        {
            base.Execute();

            _breakoutGameController.DestroyBall();
            OnComplete();
        }
    }
}
