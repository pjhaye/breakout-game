using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{    
    public class Wall : MonoBehaviour
    {
        private WallType _wallType;
        public WallType WallType
        {
            get
            {
                return _wallType;
            }
            set
            {
                _wallType = value;
            }
        }

    }
}
