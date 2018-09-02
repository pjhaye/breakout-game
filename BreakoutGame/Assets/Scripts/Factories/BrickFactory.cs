using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class BrickFactory : MonoBehaviour
    {
        [SerializeField]
        private GameObject _brickPrefab;
        [SerializeField]
        private BrickColorMaterialPair[] _brickColorsToMaterials;

        public Brick CreateBrick(BrickConfig brickConfig)
        {
            var brickGameObject = Instantiate(_brickPrefab);
            brickGameObject.name = _brickPrefab.name;            

            var brick = brickGameObject.GetComponent<Brick>();
            brick.SetSize(brickConfig.unitSize, brickConfig.width);            
            var material = GetMaterialFromBrickColor(brickConfig.color);
            brick.SetMaterial(material);
            return brick;
        }

        private Material GetMaterialFromBrickColor(BrickColor color)
        {
            foreach(var brickColorMaterialPair in _brickColorsToMaterials)
            {
                if(brickColorMaterialPair.color == color)
                {
                    return brickColorMaterialPair.material;
                }
            }
            return null;
        }
    }
}

