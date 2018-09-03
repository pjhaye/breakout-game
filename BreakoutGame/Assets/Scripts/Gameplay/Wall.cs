using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{    
    public class Wall : MonoBehaviour, IBallHittable
    {
        private WallType _wallType;
        public WallType WallType
        {
            get
            {
                return _wallType;
            }
            set
            {
                _wallType = value;
            }
        }

        public void OnHitByBall(
            Ball ball, 
            Vector3 relativeVelocity, 
            Vector3 contactNormal)
        {
            Debug.Log("Wall.OnHitByBall()");
        }
    }
}
