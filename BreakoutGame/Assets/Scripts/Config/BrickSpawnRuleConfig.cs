using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    [System.Serializable]
    public class BrickSpawnRuleConfig
    {
        public float chance = 1.0f;
        public float minColumnPercent = 0.0f;
        public float maxColumnPercent = 1.0f;
        public BrickColor[] brickColors;       
    }
}