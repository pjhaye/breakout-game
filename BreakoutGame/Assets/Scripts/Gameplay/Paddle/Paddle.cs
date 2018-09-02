using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class Paddle : MonoBehaviour, IPlayerControllable
    {
        private PaddleMovement _paddleMovement;

        public PaddleMovement PaddleMovement
        {
            get
            {
                return _paddleMovement;
            }
        }

        private void Awake()
        {
            _paddleMovement = GetComponent<PaddleMovement>();
        }        

        public void SetWidth(float value)
        {
            transform.localScale = new Vector3(value, 1.0f, 1.0f);
        }

        public void OnAxisInput(Vector2 axis)
        {
            PaddleMovement.AccelerateInDirection(axis, Time.deltaTime);
        }
    }
}