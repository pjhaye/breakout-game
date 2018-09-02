using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    [CreateAssetMenu()]
    public class LevelConfig : ScriptableObject
    {
        [Tooltip("Top-center position of all spawned bricks, relative " +
                 "to the game board")]
        public Vector2 brickTopCenterPosition;        
        [Tooltip("Config for each row starting top to bottom")]
        public RowConfig[] rowConfigs;        
    }
}