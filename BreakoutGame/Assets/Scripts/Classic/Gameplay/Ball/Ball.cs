using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace BreakoutGame
{
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        private GameObject _impactParticlePrefab;

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

        public float Speed
        {
            get
            {
                return Velocity.magnitude;
            }
            set
            {
                if(Math.Abs(Velocity.magnitude) < float.Epsilon)
                {
                    Velocity = Vector3.forward;
                }
                Velocity = Velocity.normalized * value;
            }
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            var scale = transform.localScale;
            transform.localScale = Vector3.zero;
            transform.DOScale(scale, 0.35f).SetEase(Ease.OutBack);
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

                CreateImpactParticle(
                    other.contacts[0].point, 
                    Quaternion.LookRotation(other.contacts[0].normal).eulerAngles);
            }                        
        }

        private void CreateImpactParticle(Vector3 position, Vector3 rotation)
        {
            var impactParticleGameObject = Instantiate(_impactParticlePrefab);
            impactParticleGameObject.transform.position = position;
            impactParticleGameObject.transform.rotation = Quaternion.Euler(rotation);
        }
    }
}