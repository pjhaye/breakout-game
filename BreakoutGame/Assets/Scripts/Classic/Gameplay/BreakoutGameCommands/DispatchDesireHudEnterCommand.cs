using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class DispatchDesireHudEnterCommand : BreakoutGameCommand
    {
        public DispatchDesireHudEnterCommand(BreakoutGameController breakoutGameController) :
            base(breakoutGameController)
        {

        }

        public override void Execute()
        {
            base.Execute();
            _breakoutGameController.DispatchDesireHudEnter();
            OnComplete();
        }
    }
}