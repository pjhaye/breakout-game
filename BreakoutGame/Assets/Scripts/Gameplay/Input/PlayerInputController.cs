using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class PlayerInputController : MonoBehaviour
    {
        private IPlayerControllable _target;

        public IPlayerControllable Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;

            }
        }
        
        public Vector2 LeftAxis
        {
            get
            {
                var x = Input.GetAxis("Horizontal");
                var y = Input.GetAxis("Vertical");
                return new Vector2(x, y);
            }
        }

        void Update()
        {
            Target.OnAxisInput(LeftAxis);
        }
    }
}