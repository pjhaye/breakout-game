using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    [CreateAssetMenu()]
    public class LevelConfig : ScriptableObject
    {                
        [Tooltip("Config for each row starting top to bottom")]
        public RowConfig[] rowConfigs;
        [Tooltip("Settings that should be used by the Ball for this level")]
        public BallConfig ballConfig;

    }
}