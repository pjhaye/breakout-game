using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BreakoutGame
{
    public class Command
    {
        public event Action<Command> Completed;

        protected Command()
        {

        }

        public virtual void Execute()
        {

        }

        public virtual void OnComplete()
        {
            if(Completed != null)
            {
                Completed(this);
            }
        }
    }
}