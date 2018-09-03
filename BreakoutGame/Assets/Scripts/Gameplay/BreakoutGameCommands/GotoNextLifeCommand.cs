using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class GotoNextLifeCommand : BreakoutGameCommand
    {
        public GotoNextLifeCommand(BreakoutGameController breakoutGameController) :
            base(breakoutGameController)
        {

        }

        public override void Execute()
        {
            base.Execute();

            _breakoutGameController.GotoNextLife();
            OnComplete();
        }
    }
}