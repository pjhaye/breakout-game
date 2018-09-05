using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class FadeOutCommand : BreakoutGameCommand
    {
        public FadeOutCommand(BreakoutGameController breakoutGameController) :
            base(breakoutGameController)
        {

        }

        public override void Execute()
        {
            base.Execute();

            _breakoutGameController.FadeOut();
            OnComplete();
        }
    }
}