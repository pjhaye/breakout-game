using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    [CreateAssetMenu()]
    public class GameplayConfig : ScriptableObject
    {
        public int numLives = 3;
    }
}