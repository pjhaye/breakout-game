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
        public float horizontalPaddingPercent = 0.05f;
        public float verticalPaddingPercent = 0.05f;
        public float unitSize = 1.0f;
        public float brickMeshScale = 0.95f;
    }
}