using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace BreakoutGame
{
    public class FadeUi : AnimatedUi
    {
        [SerializeField]
        private float _fadeInDuration = 1.0f;
        [SerializeField]
        private float _fadeInDelay = 0.0f;
        [SerializeField]
        private float _fadeOutDuration = 1.0f;
        [SerializeField]
        private float _fadeOutDelay = 0.0f;

        private float _baseAlpha = 0.0f;

        private CanvasGroup _canvasGroup;      
        
        private CanvasGroup CanvasGroup
        {
            get
            {
                if(_canvasGroup == null)
                {                    
                    _canvasGroup = GetComponent<CanvasGroup>();
                    _baseAlpha = _canvasGroup.alpha;
                }
                return _canvasGroup;
            }
        }

        private void Awake()
        {
            
        }

        private void OnEnable()
        {
          
        }

        public override void ShowUi()
        {
            base.ShowUi();
            if (CanvasGroup == null)
            {
                Debug.Log("No image.");
                OnShowUiComplete();
                return;
            }
            CanvasGroup.alpha = 0.0f;
            var fadeTween = CanvasGroup.DOFade(_baseAlpha, _fadeInDuration).SetDelay(_fadeInDelay);
            fadeTween.onComplete = OnFadeInCompelete;
        }

        private void OnFadeInCompelete()
        {
            OnShowUiComplete();
        }

        public override void ShowUiInstant()
        {
            base.ShowUiInstant();
            if (CanvasGroup == null)
            {
                return;
            }
            CanvasGroup.alpha = _baseAlpha; 
        }

        public override void HideUi()
        {
            base.HideUi();
            if (CanvasGroup == null)
            {
                OnHideUiComplete();
                return;
            }
            var fadeTween = CanvasGroup.DOFade(0.0f, _fadeOutDuration).SetDelay(_fadeOutDelay);
            fadeTween.onComplete = OnFadeOutCompelete;
        }

        private void OnFadeOutCompelete()
        {            
            OnHideUiComplete();
        }

        public override void HideUiInstant()
        {
            base.HideUiInstant();
            if (CanvasGroup == null)
            {

                return;
            }
            CanvasGroup.alpha = 0.0f;
        }        
    }
}