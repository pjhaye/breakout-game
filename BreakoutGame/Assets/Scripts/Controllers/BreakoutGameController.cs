﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class BreakoutGameController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _brickFactoryPrefab;
        [SerializeField]
        private GameObject _ballFactoryPrefab;

        private LevelConfig[] _levels;
        private BrickFactory _brickFactory;
        private BallFactory _ballFactory;
        private BrickGenerator _brickGenerator;
        private CameraRigController _cameraRig;
        private List<Brick> _bricks = new List<Brick>();
        private Paddle _paddle;
        private PlayerInputController _playerInputController;
        private int _levelIndex = 0;

        public LevelConfig[] Levels
        {
            get
            {
                return _levels;
            }
            set
            {
                _levels = value;
            }
        }
        
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

        public float HorizontalPaddingPercent
        {
            get;
            set;
        }

        public float VerticalPaddingPercent
        {
            get;
            set;
        }

        public float UnitSize
        {
            get;
            set;
        }

        public float BrickMeshScale
        {
            get;
            set;
        }

        public float PaddedGameBoardWidth
        {
            get
            {
                return GameBoardWidth - (GameBoardWidth * HorizontalPaddingPercent);
            }
        }

        public float PaddedGameBoardHeight
        {
            get
            {
                return GameBoardHeight - (GameBoardHeight * VerticalPaddingPercent);
            }
        }

        public LevelConfig CurrentLevelConfig
        {
            get
            {
                return Levels[_levelIndex];
            }
        }

        public Vector3 BallStartPosition
        {
            get
            {
                return new Vector3(
                    0.0f,
                    0.0f,
                    -(PaddedGameBoardHeight * 0.5f) + CurrentLevelConfig.ballConfig.startOffsetY);
            }
        }                

        private void Awake()
        {
            _playerInputController = GetComponent<PlayerInputController>();

            var brickFactoryGameObject = Instantiate(_brickFactoryPrefab);
            brickFactoryGameObject.name = _brickFactoryPrefab.name;
            _brickFactory = brickFactoryGameObject.GetComponent<BrickFactory>();

            var ballFactoryGameObject = Instantiate(_ballFactoryPrefab);
            ballFactoryGameObject.name = _ballFactoryPrefab.name;
            _ballFactory = ballFactoryGameObject.GetComponent<BallFactory>();
        }

        private void Start()
        {
            GenerateLevel(CurrentLevelConfig);
            CreateBall();
        }

        public void GenerateLevel(LevelConfig levelConfig)
        {
            _brickGenerator = new BrickGenerator(_brickFactory, levelConfig);
            _brickGenerator.GenerateBricks(this);
        }
      
        public void AddWall(Wall wall)
        {
            wall.transform.SetParent(transform, true);
        }

        public void AddBrick(Brick brick)
        {
            _bricks.Add(brick);
            brick.SetMeshScale(BrickMeshScale);
            brick.transform.SetParent(transform, true);
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
            _paddle.transform.localPosition = 
                new Vector3(
                    0.0f, 
                    0.0f, 
                    -GameBoardHeight * 0.5f * UnitSize);
            _playerInputController.Target = _paddle;
        }        

        public void CreateBall()
        {
            var ball = _ballFactory.CreateBall(CurrentLevelConfig.ballConfig);
            ball.transform.position = BallStartPosition * UnitSize;
        }

        public void ClearBricks()
        {
            foreach(var brick in _bricks)
            {
                Destroy(brick.gameObject);
            }
            _bricks = new List<Brick>();
        }
    }
}