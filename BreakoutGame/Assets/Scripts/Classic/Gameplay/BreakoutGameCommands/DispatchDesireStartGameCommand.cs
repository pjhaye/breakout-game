using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class DispatchDesireStartGameCommand : BreakoutGameCommand
    {
        public DispatchDesireStartGameCommand(BreakoutGameController breakoutGameController) :
            base(breakoutGameController)
        {

        }

        public override void Execute()
        {
            base.Execute();
            _breakoutGameController.DispatchDesireStartGameScreen();
            OnComplete();
        }
    }
}