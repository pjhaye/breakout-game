using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class BreakoutGameController : MonoBehaviour
    {
        private CameraRigController _cameraRig;
        
        public void AddWall(Wall wall)
        {
            wall.transform.SetParent(transform, true);
        }

        public void SetCameraRig(CameraRigController value)
        {
            _cameraRig = value;
            _cameraRig.transform.SetParent(transform);
        }
    }
}