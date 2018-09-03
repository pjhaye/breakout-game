using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class Ball : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Vector3 _velocity;

        public Vector3 Velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }        

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void SetRadius(float radius)
        {
            transform.localScale = new Vector3(radius, radius, radius);
        }

        public void Launch(Vector3 velocity)
        {
            Velocity = velocity;
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = _velocity;
        }

        private void OnCollisionEnter(Collision other)
        {
            var hittables = other.gameObject.GetComponents<IBallHittable>();
            foreach(var hittable in hittables)
            {
                hittable.OnHitByBall(
                    this, 
                    other.relativeVelocity, 
                    other.contacts[0].normal);
            }                        
        }
    }
}