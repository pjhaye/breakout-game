using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class Brick : MonoBehaviour
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
    }
}