using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class Paddle : MonoBehaviour, IPlayerControllable
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetWidth(float value)
        {
            transform.localScale = new Vector3(value, 1.0f, 1.0f);
        }

        public void OnAxisInput(Vector2 axis)
        {
            
        }
    }
}