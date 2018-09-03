using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class LevelController
    {
        private int _currentLevelIndex = 0;
        private LevelConfig[] _levels;

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
        
        public LevelConfig CurrentLevelConfig
        {
            get
            {
                var index = Mathf.Min(_levels.Length - 1, _currentLevelIndex);
                return _levels[index];
            }
        }

        public int LevelNumber
        {
            get
            {
                return _currentLevelIndex + 1;
            }
        }        

        public void GotoNextLevel()
        {
            _currentLevelIndex++;
        }
    }
}