using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class DebugLogCommand : Command
    {
        private readonly string _text;

        public DebugLogCommand(string text)
        {
            _text = text;
        }

        public override void Execute()
        {
            Debug.Log(_text);
            OnComplete();
        }
    }
}