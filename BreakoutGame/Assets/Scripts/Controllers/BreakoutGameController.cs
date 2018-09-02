using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class BreakoutGameController : MonoBehaviour
    {
        private CameraRigController _cameraRig;
        private Paddle _paddle;

        public float GameBoardWidth
        {
            get;
            set;
        }

        public float GameBoardHeight
        {
            get;
            set;
        }
        
        public void AddWall(Wall wall)
        {
            wall.transform.SetParent(transform, true);
        }

        public void AssignCameraRig(CameraRigController value)
        {
            _cameraRig = value;
            _cameraRig.transform.SetParent(transform);
        }

        public void AssignPaddle(Paddle paddle)
        {
            _paddle = paddle;
            _paddle.transform.SetParent(transform);
            _paddle.transform.localPosition = new Vector3(0.0f, 0.0f, -GameBoardHeight * 0.5f);
        }
    }
}