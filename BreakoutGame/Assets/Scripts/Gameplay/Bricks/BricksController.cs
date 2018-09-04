using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace BreakoutGame
{
    public class BricksController
    {
        public event Action<Brick> BrickDestroyed;
        public event Action<Brick> BrickHit;

        private List<Brick> _bricks = new List<Brick>();
        private HashSet<BrickColor> _brickColorsHit = new HashSet<BrickColor>();

        public int NumBricks
        {
            get
            {
                return _bricks.Count;
            }
        }

        public bool AreAllBricksDestroyed
        {
            get
            {
                return NumBricks <= 0;
            }
        }

        public int NumBrickColorsHit
        {
            get
            {
                return _brickColorsHit.Count;
            }
        }

        public void AddBrick(Brick brick)
        {
            _bricks.Add(brick);            
            brick.Destroyed += OnBrickDestroy;
            brick.Hit += OnBrickHit;
        }  

        private void OnBrickHit(Brick brick)
        {
            _brickColorsHit.Add(brick.Color);
            if(BrickHit != null)
            {
                BrickHit(brick);
            }
        }
        
        private void OnBrickDestroy(Brick brick)
        {
            _bricks.Remove(brick);
            if (BrickDestroyed != null)
            {
                BrickDestroyed(brick);
            }            
        }

        public void ClearBricks()
        {
            foreach (var brick in _bricks)
            {
                Object.Destroy(brick.gameObject);
            }
            _bricks = new List<Brick>();
            _brickColorsHit = new HashSet<BrickColor>();
        }
    }
}