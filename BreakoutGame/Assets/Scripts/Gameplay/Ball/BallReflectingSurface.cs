using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class BallReflectingSurface : MonoBehaviour, IBallHittable
    {
        private const float Epsilon = 0.1f;

        public void OnHitByBall(Ball ball, Vector3 relativeVelocity, Vector3 contactNormal)
        {
            ReflectBall(ball, relativeVelocity, contactNormal);
        }

        private void ReflectBall(Ball ball, Vector3 relativeVelocity, Vector3 contactNormal)
        {
            var dot = Vector3.Dot(ball.Velocity.normalized, contactNormal);
            if (dot > 0.0f)
            {
                return;
            }
            var reflectedVelocity = Vector3.Reflect(ball.Velocity, contactNormal);
            ball.Velocity = reflectedVelocity;            
        }
    }
}