using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    [CreateAssetMenu()]
    public class CameraConfig : ScriptableObject
    {
        public Vector3 baseCameraPosition;
        public Vector3 baseCameraRotation;
        public float baseCameraFov;
        public float movementSmoothTime = 0.5f;
        public float lookRotationSpeed = 1.0f;
        public float paddleFollowCoefficient = 0.15f;
        public float ballLookCoefficient = 0.15f;
    }
}
