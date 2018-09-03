using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class ScoreController
    {
        private int _score;
        public int Score
        {
            get
            {
                return _score;
            }            
        }
        
        public void ResetScore()
        {
            _score = 0;
        }

        public void AddScore(int amount)
        {
            _score += amount;
        }
    }
}