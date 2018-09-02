using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class Brick : MonoBehaviour, IBallHittable
    {
        [SerializeField]
        private MeshRenderer _baseMeshRenderer;

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

        public void OnHitByBall(Ball ball)
        {
            Debug.Log("Brick.OnHitByBall()");
        }
    }
}