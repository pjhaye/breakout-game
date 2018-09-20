using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class HideUiAfterSeconds : MonoBehaviour
    {
        [SerializeField]
        private float _secondsToDisplay = 3.0f;

        private float _timeLeft;

        private AnimatedUi _animatedUi;

        private void OnEnable()
        {
            _timeLeft = _secondsToDisplay;
        }

        private void Awake()
        {
            _animatedUi = GetComponent<AnimatedUi>();
        }

        private void Update()
        {
            if (_timeLeft > 0.0f)
            {
                _timeLeft -= Time.deltaTime;
                if (_timeLeft <= 0.0f)
                {
                    OnTimeElapse();
                }
            }
        }

        private void OnTimeElapse()
        {
            _animatedUi.HideUi();
        }
    }
}