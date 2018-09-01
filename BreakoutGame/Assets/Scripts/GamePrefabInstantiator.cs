using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BreakoutGame
{
    public class GamePrefabInstantiator : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _prefabsToInstantiate;

        private void Start()
        {
            foreach(var prefabToInstantiate in _prefabsToInstantiate)
            {
                var gameObject = Instantiate(prefabToInstantiate);
                gameObject.name = prefabToInstantiate.name;
            }
            GameObject.Destroy(gameObject);
        }
    }
} 