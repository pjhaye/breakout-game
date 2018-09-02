using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class Ball : MonoBehaviour
    {
        private Rigidbody _rigidbody;

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
            _rigidbody.velocity = velocity;
        }

        private void OnCollisionEnter(Collision other)
        {
            var ballHittable = other.gameObject.GetComponent<IBallHittable>();
            var isHittable = ballHittable != null;
            if(!isHittable)
            {
                return;
            }

            ballHittable.OnHitByBall(this);
        }
    }
}