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

        private List<Brick> _bricks = new List<Brick>();

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

        public void AddBrick(Brick brick)
        {
            _bricks.Add(brick);            
            brick.Destroyed += OnBrickDestroy;            
        }  
        
        private void OnBrickDestroy(Brick brick)
        {
            if(BrickDestroyed != null)
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
        }
    }
}