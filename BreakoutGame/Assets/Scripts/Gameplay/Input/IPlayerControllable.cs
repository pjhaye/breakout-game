using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public interface IPlayerControllable
    {
        void OnAxisInput(Vector2 axis);        
    }
}