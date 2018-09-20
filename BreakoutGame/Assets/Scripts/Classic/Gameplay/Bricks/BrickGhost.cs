using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class BrickGhost : MonoBehaviour
    {
        [SerializeField]
        private AnimationCurve _scaleCurve;
        [SerializeField]
        private AnimationCurve _alphaCurve;
        [SerializeField]
        private float _duration = 1.0f;
        [SerializeField]
        private MeshRenderer _meshRenderer;

        private float _timeElapsed = 0.0f;
        private Vector3 _baseScale;


        private void Start()
        {
            _baseScale = transform.localScale;
        }

        void Update()
        {
            _timeElapsed += Time.deltaTime;

            if (_timeElapsed >= _duration)
            {
                Destroy(gameObject);
            }
            else
            {
                var scale = _baseScale * _scaleCurve.Evaluate(_timeElapsed);
                var alpha = _alphaCurve.Evaluate(_timeElapsed);
                transform.localScale = scale;
                _meshRenderer.material.SetColor("Color_97C4C244", Color.white * alpha);
            }
        }
    }
}