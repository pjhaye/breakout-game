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
        private BreakoutGameFactory _breakoutGameFactory;

        void Start()
        {
            var breakoutGame = _breakoutGameFactory.CreateBreakoutGame(_config);

            Destroy(gameObject);
        }
    }
}