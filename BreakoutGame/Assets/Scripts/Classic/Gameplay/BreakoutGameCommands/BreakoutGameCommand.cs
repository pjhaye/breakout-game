using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class BreakoutGameCommand : Command
    {
        protected readonly BreakoutGameController _breakoutGameController;

        public BreakoutGameCommand(
            BreakoutGameController breakoutGameController
            ) : base()
        {
            _breakoutGameController = breakoutGameController;
        }
    }
}