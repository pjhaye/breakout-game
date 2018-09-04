using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Steps;
using System;

namespace BreakoutGame
{
    public class Brick : MonoBehaviour, IBallHittable
    {
        private const float HitCooldownDuration = 0.2f;

        [SerializeField]
        private MeshRenderer _untouchedMeshRenderer;
        [SerializeField]
        private MeshRenderer _weakenedMeshRenderer;
        [SerializeField]
        private GameObject _brickGhostPrefab;            

        private BrickState _state;
        private float _hitCooldownTimeLeft = 0.0f;

        public event Action<Brick> Hit;
        public event Action<Brick> Destroyed;        

        public int Score
        {
            get;
            set;
        }

        public BrickColor Color
        {
            get;
            set;
        }

        private bool IsHitCooldownActive
        {
            get
            {
                return _hitCooldownTimeLeft > 0.0f;
            }
        }

        private void Start()
        {
            _untouchedMeshRenderer.gameObject.SetActive(true);
            _weakenedMeshRenderer.gameObject.SetActive(false);
        }

        public void SetMaterial(Material material, Material weakenedMaterial)
        {
            _untouchedMeshRenderer.material = material;
            _weakenedMeshRenderer.material = weakenedMaterial;
        }

        public void SetSize(float unitSize, float width)
        {
            transform.localScale = new Vector3(unitSize * width, unitSize, unitSize);
        }

        public void SetMeshScale(float scale)
        {
            var untouchedTransform = _untouchedMeshRenderer.gameObject.transform;
            untouchedTransform.localScale = new Vector3(scale, scale, scale);

            var weakenedTransform = _weakenedMeshRenderer.gameObject.transform;
            weakenedTransform.localScale = new Vector3(scale, scale, scale);
        }

        public void OnHitByBall(
            Ball ball, 
            Vector3 relativeVelocity, 
            Vector3 contactNormal)
        {
            if(IsHitCooldownActive)
            {
                return;
            }

            if (Hit != null)
            {
                Hit(this);
            }
            CreateGhost();
            DegradeState();
            StartHitCooldown();
        }

        private void StartHitCooldown()
        {
            _hitCooldownTimeLeft = HitCooldownDuration;
        }

        private void DegradeState()
        {
            _state++;
            switch(_state)
            {
                case BrickState.Weakened:
                    OnWeakened();
                    break;

                case BrickState.Destroyed:
                    OnDestroyed();
                    break;
            }
        }

        private void OnWeakened()
        {
            _untouchedMeshRenderer.gameObject.SetActive(false);
            _weakenedMeshRenderer.gameObject.SetActive(true);
        }

        private void OnDestroyed()
        {
            Explode();
            
        }

        private void CreateGhost()
        {
            var ghost = Instantiate(_brickGhostPrefab);
            ghost.transform.position = transform.position;
            ghost.transform.localScale = transform.localScale;
            ghost.transform.localRotation = transform.localRotation;
        }

        private void FixedUpdate()
        {
            if (_hitCooldownTimeLeft > 0.0f)
            {
                _hitCooldownTimeLeft -= Time.deltaTime;
                if(_hitCooldownTimeLeft <= 0.0f)
                {
                    _hitCooldownTimeLeft = 0.0f;
                }
            }
        }

        private void Explode()
        {
            if(Destroyed != null)
            {
                Destroyed(this);
            }
            Destroy(gameObject);
        }
    }
}