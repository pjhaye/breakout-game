using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame.BreakoutGameStates
{
    public class BreakoutGameState : State<BreakoutGameController>
    {
        public BreakoutGameState(BreakoutGameController context) : base(context)
        {
            
        }

        public virtual void OnBallFail(Ball ball)
        {

        }        
    }
}