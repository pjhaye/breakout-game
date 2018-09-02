using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    [CreateAssetMenu()]
    public class GameBoardConfig : ScriptableObject
    {
        public int gameBoardWidth;
        public int gameBoardHeight;
        public float unitSize = 1.0f;
    }
}