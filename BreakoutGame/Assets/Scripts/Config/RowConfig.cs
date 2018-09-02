using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    [System.Serializable]
    public class RowConfig
    {        
        public int numColumns;
        public BrickSpawnRuleConfig[] brickSpawnRuleConfigs;
    }
}