using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Steps;
using System;

namespace BreakoutGame
{
    public class Brick : MonoBehaviour, IBallHittable
    {
        [SerializeField]
        private MeshRenderer _untouchedMeshRenderer;
        [SerializeField]
        private MeshRenderer _weakenedMeshRenderer;

        private BrickState _state;

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
            if (Hit != null)
            {
                Hit(this);
            }
            DegradeState();
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