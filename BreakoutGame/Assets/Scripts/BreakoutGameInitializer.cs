using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class BreakoutGameInitializer : MonoBehaviour
    {
        [SerializeField]
        private BreakoutGameConfig _config;
        [SerializeField]
        private GameObject _breakoutGameFactoryPrefab;
        [SerializeField]
        private LevelConfig[] _levels;

        private BreakoutGameFactory _breakoutGameFactory;

        void Start()
        {

            var breakoutGameFactoryGameObject = 
                Instantiate(_breakoutGameFactoryPrefab);
            breakoutGameFactoryGameObject.name = _breakoutGameFactoryPrefab.name;

            _breakoutGameFactory = breakoutGameFactoryGameObject
                .GetComponent<BreakoutGameFactory>();

            _breakoutGameFactory.CreateBreakoutGame(_config, _levels);

            Destroy(gameObject);
        }
    }
}