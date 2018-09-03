using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame.BreakoutGameStates
{
    public class BreakoutGameStateMachine : StateMachine<BreakoutGameController>
    {
        public new BreakoutGameState State
        {
            get
            {
                return (BreakoutGameState)base.State;
            }
            set
            {
                base.State = value;
            }
        }
        

        public void OnBallFail(Ball ball)
        {
            if(State != null)
            {
                State.OnBallFail(ball);
            }
        }
    }
}
