using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class Ball : MonoBehaviour
    {
        public void SetRadius(float radius)
        {
            transform.localScale = new Vector3(radius, radius, radius);
        }
    }
}