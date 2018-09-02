using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class PaddleMovement : MonoBehaviour
    {
        private const float Epsilon = 0.005f;

        [SerializeField]
        private float _maximumSpeed = 1.0f;
        [SerializeField]
        private float _acceleration = 1.0f;
        [SerializeField]
        private float _decceleration = 1.0f;
        [SerializeField]
        private bool _autoDeccelerate = true;

        private bool _movedLastFrame = false;
        private Vector3 _velocity = Vector3.zero;
        private Rigidbody _rigidbody;        

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            _rigidbody.useGravity = false;
        }

        private void FixedUpdate()
        {
            var shouldDeccelerate = _autoDeccelerate && !_movedLastFrame;            
            if(shouldDeccelerate)
            {
                Deccelerate(Time.deltaTime);
            }
            var delta = (_velocity * Time.deltaTime);
            var newPosition = _rigidbody.position + delta;
            _rigidbody.MovePosition(newPosition);
        }

        private void LateUpdate()
        {            
            _movedLastFrame = false;            
        }

        public void AccelerateInDirection(Vector3 direction, float deltaTime)
        {
            if(direction.magnitude <= Epsilon)
            {
                return;
            }

            var dot = Vector3.Dot(direction.normalized, _velocity.normalized);
            var reversedDirection = dot <= 0.0f;
            if(reversedDirection)
            {
                _velocity = Vector3.zero;
            }

            _velocity += direction * (_acceleration * deltaTime);
            if(_velocity.magnitude > _maximumSpeed)
            {
                _velocity = _velocity.normalized * _maximumSpeed;
            }            
            _movedLastFrame = true;
        }

        public void Deccelerate(float deltaTime)
        {
            var speed = _velocity.magnitude;

            if (speed <= Epsilon)
            {
                speed = 0.0f;
            }
            else
            {
                speed -= _decceleration * deltaTime;
                if (speed <= Epsilon)
                {
                    speed = 0.0f;
                }
            }

            _velocity = _velocity.normalized * speed;            
        }
    }
}