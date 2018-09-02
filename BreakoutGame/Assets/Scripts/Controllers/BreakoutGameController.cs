using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class BreakoutGameController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _brickFactoryPrefab;

        private BrickFactory _brickFactory;
        private CameraRigController _cameraRig;
        private Paddle _paddle;
        private PlayerInputController _playerInputController;

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

        private void Awake()
        {
            _playerInputController = GetComponent<PlayerInputController>();

            var brickFactoryGameObject = Instantiate(_brickFactoryPrefab);
            brickFactoryGameObject.name = _brickFactoryPrefab.name;
            _brickFactory = brickFactoryGameObject.GetComponent<BrickFactory>();
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
            _playerInputController.Target = _paddle;
        }
    }
}