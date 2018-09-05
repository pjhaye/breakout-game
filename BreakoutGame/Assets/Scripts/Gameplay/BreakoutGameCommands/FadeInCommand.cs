using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class FadeInCommand : BreakoutGameCommand
    {
        public FadeInCommand(BreakoutGameController breakoutGameController) : 
            base(breakoutGameController)
        {

        }

        public override void Execute()
        {
            base.Execute();

            _breakoutGameController.FadeIn();
            OnComplete();
        }
    }
}