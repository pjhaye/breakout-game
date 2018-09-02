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
    }
}
