using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class SetPlayerInputEnabledCommand : BreakoutGameCommand
    {
        private readonly bool _inputEnabled;

        public SetPlayerInputEnabledCommand(
            BreakoutGameController breakoutGameController,
            bool inputEnabled) :
            base(breakoutGameController)
        {
            _inputEnabled = inputEnabled;
        }

        public override void Execute()
        {
            base.Execute();

            _breakoutGameController.SetPlayerInputEnabled(_inputEnabled);
            OnComplete();
        }
    }
}