using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class RemoveLifeCommand : BreakoutGameCommand
    {
        public RemoveLifeCommand(BreakoutGameController breakoutGameController) :
            base(breakoutGameController)
        {

        }

        public override void Execute()
        {
            base.Execute();

            _breakoutGameController.RemoveLife();
            OnComplete();
        }
    }
}