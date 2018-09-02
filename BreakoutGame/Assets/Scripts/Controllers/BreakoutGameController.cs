using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class BreakoutGameController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _brickFactoryPrefab;

        private LevelConfig[] _levels;
        private BrickFactory _brickFactory;
        private BrickGenerator _brickGenerator;
        private CameraRigController _cameraRig;
        private List<Brick> _bricks = new List<Brick>();
        private Paddle _paddle;
        private PlayerInputController _playerInputController;        

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

        private void Awake()
        {
            _playerInputController = GetComponent<PlayerInputController>();

            var brickFactoryGameObject = Instantiate(_brickFactoryPrefab);
            brickFactoryGameObject.name = _brickFactoryPrefab.name;
            _brickFactory = brickFactoryGameObject.GetComponent<BrickFactory>();            
        }

        private void Start()
        {
            GenerateLevel(Levels[0]);
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
            _paddle.transform.localPosition = new Vector3(0.0f, 0.0f, -GameBoardHeight * 0.5f * UnitSize);
            _playerInputController.Target = _paddle;
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