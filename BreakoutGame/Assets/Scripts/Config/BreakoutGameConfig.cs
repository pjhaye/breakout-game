using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    [CreateAssetMenu()]
    public class BreakoutGameConfig : ScriptableObject
    {
        public GameBoardConfig gameBoardConfig;
        public CameraConfig cameraConfig;
        public PaddleConfig paddleConfig;
    }
}