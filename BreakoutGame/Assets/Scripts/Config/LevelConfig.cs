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
    }
}