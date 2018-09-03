using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class ResetLivesCommand : BreakoutGameCommand
    {
        public ResetLivesCommand(BreakoutGameController breakoutGameController) :
            base(breakoutGameController)
        {

        }

        public override void Execute()
        {
            base.Execute();

            _breakoutGameController.ResetLives();
        }
    }
}