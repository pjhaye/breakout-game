using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace BreakoutGame
{
    public class BrickFactory : MonoBehaviour
    {
        [SerializeField]
        private GameObject _brickPrefab;
        [SerializeField]
        private BrickColorConfig[] _brickColorConfigs;

        private bool _flipNextBrick;

        public Brick CreateBrick(BrickConfig brickConfig)
        {
            var brickGameObject = Instantiate(_brickPrefab);
            brickGameObject.name = _brickPrefab.name;            

            var brick = brickGameObject.GetComponent<Brick>();
            brick.SetSize(brickConfig.unitSize, brickConfig.width);            
            var material = GetMaterialFromBrickColor(brickConfig.color);
            var weakenedMaterial = GetWeakenedMaterialFromBrickColor(brickConfig.color);
            brick.SetMaterial(material, weakenedMaterial);
            brick.Score = GetScoreFromBrickColor(brickConfig.color);
            brick.Color = brickConfig.color;

            if(_flipNextBrick)
            {
                brickGameObject.transform.Rotate(Vector3.up, 180.0f);
            }
            _flipNextBrick = !_flipNextBrick;

            return brick;
        }

        private Material GetMaterialFromBrickColor(BrickColor color)
        {
            foreach(var brickColorConfig in _brickColorConfigs)
            {
                if(brickColorConfig.color == color)
                {
                    return brickColorConfig.material;
                }
            }
            return null;
        }

        private Material GetWeakenedMaterialFromBrickColor(BrickColor color)
        {
            foreach (var brickColorConfig in _brickColorConfigs)
            {
                if (brickColorConfig.color == color)
                {
                    return brickColorConfig.weakenedMaterial;
                }
            }
            return null;
        }

        private int GetScoreFromBrickColor(BrickColor color)
        {
            foreach (var brickColorConfig in _brickColorConfigs)
            {
                if (brickColorConfig.color == color)
                {
                    return brickColorConfig.score;
                }
            }
            return 0;
        }
    }
}

