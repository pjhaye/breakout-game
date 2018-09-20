using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class LivesController
    {
        private int _defaultLives = 3;
        private int _numLives = 3;

        public int DefaultLives
        {
            get
            {
                return _defaultLives;
            }
            set
            {
                _defaultLives = value;
            }
        }

        public int NumLives
        {
            get
            {
                return _numLives;
            }            
        }     
        
        public bool IsOutOfLives
        {
            get
            {
                return NumLives <= 0;
            }
        }

        public void RemoveLife()
        {
            _numLives--;
        }

        public void ResetLives()
        {
            _numLives = _defaultLives;
        }
    }
}

