using System.Collections;
using System.Collections.Generic;
using BreakoutGame;
using UnityEngine;

namespace BreakoutGame
{
    public class BreakoutGameFactory : MonoBehaviour
    {
        [SerializeField]
        private GameObject _breakoutGamePrefab;
        [SerializeField]
        private GameObject _wallPrefab;
        [SerializeField]
        private GameObject _cornerPiecePrefab;
        [SerializeField]
        private GameObject _cameraRigPrefab;
        [SerializeField]
        private GameObject _paddlePrefab;

        public BreakoutGameController CreateBreakoutGame(BreakoutGameConfig config)
        {
            var breakoutGameController = InstantiateBreakoutGame(config);

            var gameBoardConfig = config.gameBoardConfig;
            CreateWalls(breakoutGameController, gameBoardConfig);

            var cameraConfig = config.cameraConfig;
            CreateCamera(breakoutGameController, cameraConfig);

            var paddleConfig = config.paddleConfig;
            CreatePaddle(breakoutGameController, paddleConfig);

            return breakoutGameController;
        }

        private BreakoutGameController InstantiateBreakoutGame(BreakoutGameConfig config)
        {
            var breakoutGameObject = Instantiate(_breakoutGamePrefab);
            var breakoutGameController = breakoutGameObject.GetComponent<BreakoutGameController>();
            breakoutGameObject.name = _breakoutGamePrefab.name;

            var gameBoardConfig = config.gameBoardConfig;
            breakoutGameController.GameBoardWidth = gameBoardConfig.gameBoardWidth;
            breakoutGameController.GameBoardHeight = gameBoardConfig.gameBoardHeight;

            return breakoutGameController;
        }

        private void CreateCamera(
            BreakoutGameController breakoutGameController,
            CameraConfig cameraConfig)
        {
            var cameraRigGameObject = Instantiate(_cameraRigPrefab);
            cameraRigGameObject.name = _cameraRigPrefab.name;
            var cameraRig = cameraRigGameObject.GetComponent<CameraRigController>();
            cameraRig.BaseCameraPosition = cameraConfig.baseCameraPosition;
            cameraRig.BaseCameraRotation = cameraConfig.baseCameraRotation;     
            
            breakoutGameController.AssignCameraRig(cameraRig);
        }

        private void CreateWalls(
            BreakoutGameController breakoutGameController,
            GameBoardConfig gameBoardConfig)
        {
            var gameBoardWidthHalf = gameBoardConfig.gameBoardWidth * 0.5f;
            var gameBoardHeightHalf = gameBoardConfig.gameBoardWidth * 0.5f;

            var leftWallConfig = new WallConfig
            {
                x = -gameBoardWidthHalf,
                angle = 90.0f,
                width = gameBoardConfig.gameBoardHeight,
                wallType = WallType.Left
            };
            CreateWall(breakoutGameController, leftWallConfig);

            var rightWallConfig = new WallConfig
            {
                x = gameBoardWidthHalf,
                angle = -90.0f,
                width = gameBoardConfig.gameBoardHeight,
                wallType = WallType.Right
            };
            CreateWall(breakoutGameController, rightWallConfig);

            var topWallConfig = new WallConfig
            {
                y = gameBoardHeightHalf,
                angle = 180.0f,
                width = gameBoardConfig.gameBoardWidth,
                wallType = WallType.Top
            };
            CreateWall(breakoutGameController, topWallConfig);

            var leftCornerConfig = new CornerConfig
            {
                x = -gameBoardWidthHalf,
                y = gameBoardHeightHalf,
                angle = 180.0f,
                size = 1.0f

            };
            CreateCorner(breakoutGameController, leftCornerConfig);

            var rightCornerConfig = new CornerConfig
            {
                x = gameBoardWidthHalf,
                y = gameBoardHeightHalf,
                angle = 270.0f,
                size = 1.0f

            };
            CreateCorner(breakoutGameController, rightCornerConfig);
        }

        private void CreateWall(
            BreakoutGameController breakoutGameController,
            WallConfig wallConfig)
        {
            var wallGameObject = Instantiate(_wallPrefab);
            wallGameObject.name = _wallPrefab.name;
            var wall = wallGameObject.GetComponent<Wall>();
            wall.WallType = wallConfig.wallType;

            var wallTransform = wallGameObject.transform;
            wallTransform.localPosition = new Vector3(wallConfig.x, 0.0f, wallConfig.y);
            wallTransform.localRotation = Quaternion.Euler(0.0f, wallConfig.angle, 0.0f);
            wallTransform.localScale = new Vector3(wallConfig.width, 1.0f, 1.0f);

            breakoutGameController.AddWall(wall);
        }

        private void CreateCorner(
            BreakoutGameController breakoutGameController,
            CornerConfig cornerConfig)
        {
            var wallGameObject = Instantiate(_cornerPiecePrefab);
            wallGameObject.name = _cornerPiecePrefab.name;
            var wall = wallGameObject.GetComponent<Wall>();

            var wallTransform = wallGameObject.transform;
            wallTransform.localPosition = new Vector3(cornerConfig.x, 0.0f, cornerConfig.y);
            wallTransform.localRotation = Quaternion.Euler(0.0f, cornerConfig.angle, 0.0f);
            wallTransform.localScale = new Vector3(cornerConfig.size, 1.0f, cornerConfig.size);

            breakoutGameController.AddWall(wall);
        }

        private void CreatePaddle(
            BreakoutGameController breakoutGameController,
            PaddleConfig paddleConfig)
        {
            var paddleGameObject = Instantiate(_paddlePrefab);
            paddleGameObject.name = _paddlePrefab.name;
            var paddle = paddleGameObject.GetComponent<Paddle>();
            paddle.XExtents = new Vector2(
                -breakoutGameController.GameBoardWidth * 0.5f,
                breakoutGameController.GameBoardWidth * 0.5f);

            paddle.SetWidth(paddleConfig.paddleWidth);

            breakoutGameController.AssignPaddle(paddle);
        }
    }
}