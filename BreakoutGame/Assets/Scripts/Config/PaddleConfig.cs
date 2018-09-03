using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    [CreateAssetMenu()]
    public class PaddleConfig : ScriptableObject
    {
        public float paddleWidth = 2.0f;
        public float maximumSpeed = 8.0f;
        public float acceleration = 50.0f;
        public float decceleration = 100.0f;
        public float maxBallAngleChange = 15.0f;
    }
}