using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class DestroyParticleOnCompletion : MonoBehaviour
    {
        private ParticleSystem _particleSystem;
        
        void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }
        
        void Update()
        {
            if(!_particleSystem.IsAlive(true))
            {
                Destroy(gameObject);
            }
        }
    }
}