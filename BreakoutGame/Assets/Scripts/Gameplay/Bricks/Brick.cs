using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Steps;

namespace BreakoutGame
{
    public class Brick : MonoBehaviour, IBallHittable
    {
        [SerializeField]
        private MeshRenderer _baseMeshRenderer;

        private BrickState _state;

        public void SetMaterial(Material material)
        {
            _baseMeshRenderer.material = material;
        }

        public void SetSize(float unitSize, float width)
        {
            transform.localScale = new Vector3(unitSize * width, unitSize, unitSize);
        }

        public void SetMeshScale(float scale)
        {
            var meshTransform = _baseMeshRenderer.gameObject.transform;
            meshTransform.localScale = new Vector3(scale, scale, scale);
        }

        public void OnHitByBall(
            Ball ball, 
            Vector3 relativeVelocity, 
            Vector3 contactNormal)
        {
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

        }

        private void OnDestroyed()
        {
            Explode();
        }

        private void Explode()
        {
            Destroy(gameObject);
        }
    }
}