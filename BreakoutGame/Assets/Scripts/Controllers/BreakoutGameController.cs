using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class BreakoutGameController : MonoBehaviour
    {                
        public void AddWall(Wall wall)
        {
            wall.transform.SetParent(transform, true);
        }
    }
}