using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class ResetLivesCommand : Command
    {
        private readonly BreakoutGameController _breakoutGameController;

        public ResetLivesCommand(BreakoutGameController breakoutGameController)
        {
            _breakoutGameController = breakoutGameController;
        }

        public override void Execute()
        {
            base.Execute();

            _breakoutGameController.ResetLives();
        }
    }
}