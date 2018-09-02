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
    }
}