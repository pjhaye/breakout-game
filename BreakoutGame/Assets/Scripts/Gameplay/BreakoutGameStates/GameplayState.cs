using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame.BreakoutGameStates
{
    public class GameplayState : BreakoutGameState
    {

        public GameplayState(BreakoutGameController context) : base(context)
        {

        }

        public override void OnBallFail(Ball ball)
        {
            base.OnBallFail(ball);
            Context.StartLoseLifeSequence();
        }
    }
}
