using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    [CreateAssetMenu()]
    public class BallConfig : ScriptableObject
    {
        public float ballRadius = 0.5f;
        public float startOffsetY = -1.0f;
        public float minLaunchAngle = -45.0f;
        public float maxLaunchAngle = 45.0f;
        public float minBallSpawnXPercent = 0.1f;
        public float maxBallSpawnXPercent = 0.9f;
        public float ballLaunchSpeed = 10.0f;
    }
}