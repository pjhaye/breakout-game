using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public interface IBallHittable
    {
        void OnHitByBall(Ball ball);
    }
}
