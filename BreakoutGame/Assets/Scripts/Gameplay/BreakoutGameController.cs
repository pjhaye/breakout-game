using System.Collections;
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

        private LevelConfig[] _levels;
        private BrickFactory _brickFactory;
        private BallFactory _ballFactory;
        private BrickGenerator _brickGenerator;
        private CameraRigController _cameraRig;
        private List<Brick> _bricks = new List<Brick>();
        private Paddle _paddle;
        private PlayerInputController _playerInputController;
        private int _levelIndex = 0;
        private Ball _ball;
        private BreakoutGameStateMachine _stateMachine;

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
            
            _stateMachine = new BreakoutGameStateMachine();            
        }

        private void Start()
        {
            State = new GameplayState(this);
            GenerateLevel(CurrentLevelConfig);
            StartBallLaunchSequence();
        }

        private void Update()
        {
            _stateMachine.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            CheckForBallFail();
            _stateMachine.FixedUpdate(Time.deltaTime);
        }

        private void LateUpdate()
        {
            _stateMachine.LateUpdate(Time.deltaTime);
        }

        private void CheckForBallFail()
        {
            if (_ball != null)
            {
                var ballY = _ball.transform.localPosition.z;
                if (ballY <= BallFailY * UnitSize)
                {
                    OnBallFail();
                }
            }
        }

        private void OnBallFail()
        {

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
                    -GameBoardHeight * 0.5f * UnitSize + UnitSize * 0.5f);
            _playerInputController.Target = _paddle;
        }        

        public void CreateBall()
        {
            var ballConfig = CurrentLevelConfig.ballConfig;
            _ball = _ballFactory.CreateBall(ballConfig);
            var startPosition = BallStartPosition;
            var leftMost = -GameBoardWidth * 0.5f + ballConfig.minBallSpawnXPercent * GameBoardWidth;
            var rightMost = -GameBoardWidth * 0.5f + ballConfig.maxBallSpawnXPercent * GameBoardWidth;
            var startX = Random.Range(leftMost, rightMost);
            startPosition.x = startX;
            _ball.transform.position = startPosition * UnitSize;
        }

        public void LaunchBall()
        {
            var ballConfig = CurrentLevelConfig.ballConfig;
            var angle = Random.Range(
                ballConfig.minLaunchAngle,
                ballConfig.maxLaunchAngle);
            LaunchBallAtAngle(angle, ballConfig.ballLaunchSpeed);
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