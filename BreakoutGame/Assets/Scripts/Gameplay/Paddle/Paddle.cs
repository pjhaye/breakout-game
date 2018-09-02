using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class Paddle : MonoBehaviour, IPlayerControllable
    {
        private PaddleMovement _paddleMovement;
        private Vector2 _xExtents = new Vector2(-5, 5);
        private float _width = 2.0f;
        private Rigidbody _rigidbody;

        public PaddleMovement PaddleMovement
        {
            get
            {
                return _paddleMovement;
            }
        }

        public Vector2 XExtents
        {
            get
            {
                return _xExtents;
            }
            set
            {
                _xExtents = value;
            }
        }

        public float Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        private void Awake()
        {
            _paddleMovement = GetComponent<PaddleMovement>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            ProcessPositionConstraints();
        }

        private void ProcessPositionConstraints()
        {
            var position = _rigidbody.position;
            var left = position.x - Width * 0.5f;
            var right = position.x + Width * 0.5f;
            if (left < XExtents.x)
            {
                position.x = XExtents.x + Width * 0.5f;
            }
            else if(right > XExtents.y)
            {
                position.x = XExtents.y - Width * 0.5f;
            }
            _rigidbody.position = position;
        }

        public void SetWidth(float value)
        {
            Width = value;
            transform.localScale = new Vector3(value, 1.0f, 1.0f);
        }

        public void OnAxisInput(Vector2 axis)
        {
            axis.y = 0.0f;            
            PaddleMovement.AccelerateInDirection(axis, Time.deltaTime);
        }
    }
}