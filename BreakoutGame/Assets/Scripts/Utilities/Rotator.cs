using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _rotationPerSecond;

        private void FixedUpdate()
        {
            transform.Rotate(_rotationPerSecond * Time.deltaTime, Space.Self);
        }
    }
}
