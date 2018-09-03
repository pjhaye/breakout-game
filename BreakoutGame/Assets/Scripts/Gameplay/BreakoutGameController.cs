﻿using System.Collections;
using System.Collections.Generic;
using BreakoutGame.BreakoutGameStates;
using UnityEngine;

namespace BreakoutGame
{
    public class BreakoutGameController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _brickFactoryPrefab;
        [SerializeField]
        private GameObject _ballFactoryPrefab;
        [SerializeField]
        private GameObject _hudPrefab;

        private LevelConfig[] _levels;
        private BallFailDetector _ballFailDetector;
        private BrickFactory _brickFactory;
        private BallFactory _ballFactory;
        private BrickGenerator _brickGenerator;
        private CameraRigController _cameraRig;        
        private Paddle _paddle;
        private PlayerInputController _playerInputController;
        private BricksController _bricksController;
        private LivesController _livesController;
        private ScoreController _scoreController;
        private LevelController _levelController;
        private Ball _ball;
        private BreakoutGameStateMachine _stateMachine;
        private HudUi _hudUi;        

        public LivesController LivesController
        {
            get
            {
                return _livesController;
            }
        }

        public ScoreController ScoreController
        {
            get
            {
                return _scoreController;
            }
        }

        public LevelController LevelController
        {
            get
            {
                return _levelController;
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

        public Ball Ball
        {
            get
            {
                return _ball;
            }
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
                return LevelController.CurrentLevelConfig;
            }
        }

        public Vector3 BallStartPosition
        {
            get
            {
                var startOffsetY = CurrentLevelConfig.ballConfig.startOffsetY;
                return new Vector3(
                    0.0f,
                    0.0f,
                    -(PaddedGameBoardHeight * 0.5f) + startOffsetY);
            }
        }     
        
        public float BallFailY
        {
            get
            {
                return -GameBoardHeight * 0.5f;
            }
        }

        public BreakoutGameState State
        {
            get
            {
                return _stateMachine.State;
            }
            set
            {
                _stateMachine.State = value;
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

            _bricksController = new BricksController();
            _bricksController.BrickDestroyed += OnBrickDestroy;
            _livesController = new LivesController();
            _scoreController = new ScoreController();
            _levelController = new LevelController();

            _stateMachine = new BreakoutGameStateMachine();                        
        }

        private void Start()
        {
            State = new GameplayState(this);
            CreateHud();
            ResetLives();
            GenerateLevel(CurrentLevelConfig);
            StartBallLaunchSequence();                   
        }

        private void CreateHud()
        {
            var hudGameObject = Instantiate(_hudPrefab);
            hudGameObject.name = _hudPrefab.name;
            _hudUi = hudGameObject.GetComponent<HudUi>();            
            _hudUi.LivesUi.LivesController = LivesController;
            _hudUi.ScoreUi.ScoreController = ScoreController;
            _hudUi.LevelUi.LevelController = LevelController;
        }

        private void Update()
        {
            _stateMachine.Update(Time.deltaTime);            
        }

        private void FixedUpdate()
        {
            if (_ballFailDetector != null)
            {
                _ballFailDetector.CheckForBallFail();
            }

            _stateMachine.FixedUpdate(Time.deltaTime);
        }

        private void LateUpdate()
        {
            _stateMachine.LateUpdate(Time.deltaTime);
        }
       
        public void OnBallFail(Ball ball)
        {
            _stateMachine.OnBallFail(ball);
        }

        public void StartBallLaunchSequence()
        {
            var sequence = new CommandSequence();
            sequence.AddCommand(new DelayCommand(1.0f, this));
            sequence.AddCommand(new CreateBallCommand(this));
            sequence.AddCommand(new DelayCommand(1.0f, this));
            sequence.AddCommand(new LaunchBallCommand(this));
            sequence.Execute();
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
            _bricksController.AddBrick(brick);
            brick.SetMeshScale(BrickMeshScale);
            brick.transform.SetParent(transform, true);
        }

        private void OnBrickDestroy(Brick brick)
        {
            ScoreController.AddScore(brick.Score);

            BeatLevelIfNoBricks();
        }

        private void BeatLevelIfNoBricks()
        {
            if(!_bricksController.AreAllBricksDestroyed)
            {
                return;
            }

            StartLevelCompleteSequence();
        }

        private void StartLevelCompleteSequence()
        {
            var sequence = new CommandSequence();
            sequence.AddCommand(new DestroyBallCommand(this));
            sequence.AddCommand(new DelayCommand(2.0f, this));
            sequence.AddCommand(new AdvanceLevelCommand(this));
            sequence.AddCommand(new StartBallLaunchSequenceCommand(this));
            sequence.Execute();
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
                    -GameBoardHeight * 0.5f * UnitSize + UnitSize * 0.5f);
            _playerInputController.Target = _paddle;
        }        

        public void CreateBall()
        {
            var ballConfig = CurrentLevelConfig.ballConfig;
            _ball = _ballFactory.CreateBall(ballConfig);
            var startPosition = BallStartPosition;            

            var minWidthPercent = ballConfig.minBallSpawnXPercent * GameBoardWidth;
            var maxWidthPercent = ballConfig.minBallSpawnXPercent * GameBoardWidth;

            var leftMost = -GameBoardWidth * 0.5f + minWidthPercent;
            var rightMost = -GameBoardWidth * 0.5f + maxWidthPercent;
            var startX = Random.Range(leftMost, rightMost);
            startPosition.x = startX;
            _ball.transform.position = startPosition * UnitSize;

            _ballFailDetector = new BallFailDetector(
                this,
                _ball,
                BallFailY * UnitSize);
        }

        public void LaunchBall()
        {
            var ballConfig = CurrentLevelConfig.ballConfig;
            var angle = Random.Range(
                ballConfig.minLaunchAngle,
                ballConfig.maxLaunchAngle);
            LaunchBallAtAngle(angle, ballConfig.ballLaunchSpeed);
        }

        public void DestroyBall()
        {
            if(_ball == null)
            {
                return;
            }
            Destroy(_ball.gameObject);
            _ball = null;
        }

        public void LaunchBallAtAngle(float angle, float speed)
        {
            var launchVector = Quaternion.Euler(0.0f, angle, 0.0f) * Vector3.forward;
            LaunchBallInDirectionAtSpeed(launchVector, speed);
        }

        public void LaunchBallInDirectionAtSpeed(Vector3 direction, float speed)
        {
            var launchVector = direction.normalized * speed;
            _ball.Launch(launchVector);
        }

        public void RemoveLife()
        {
            LivesController.RemoveLife();
        }

        public void StartLoseLifeSequence()
        {
            var sequence = new CommandSequence();
            sequence.AddCommand(new DelayCommand(2.0f, this));
            sequence.AddCommand(new DestroyBallCommand(this));
            sequence.AddCommand(new RemoveLifeCommand(this));
            sequence.AddCommand(new GotoNextLifeCommand(this));
            sequence.Execute();
        }

        public void GotoNextLife()
        {
            if(LivesController.IsOutOfLives)
            {
                StartGameOverSequence();
            }
            else
            {
                StartBallLaunchSequence();
            }
        }

        private void StartGameOverSequence()
        {

        }

        public void AdvanceLevel()
        {
            LevelController.GotoNextLevel();
            ClearBricks();
            GenerateLevel(CurrentLevelConfig);
        }

        public void ResetLives()
        {
            LivesController.ResetLives();
        }

        public void ClearBricks()
        {
            _bricksController.ClearBricks();            
        }
    }
}