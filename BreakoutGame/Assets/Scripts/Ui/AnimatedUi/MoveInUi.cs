using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace BreakoutGame
{
    public class MoveInUi : AnimatedUi
    {
        [SerializeField]
        private Vector2 _moveInFrom;
        [SerializeField]
        private float _moveInSpeed = 0.35f;
        [SerializeField]
        private float _moveInDelay = 0.0f;
        [SerializeField]
        private Vector2 _moveOutTo;
        [SerializeField]
        private float _moveOutSpeed = 0.35f;
        [SerializeField]
        private float _moveOutDelay = 0.0f;

        private RectTransform _rectTransform;
        private Vector2 _basePivot;

        private RectTransform RectTransform
        {
            get
            {
                if(_rectTransform == null)
                {
                    _rectTransform = GetComponent<RectTransform>();
                    _basePivot = _rectTransform.pivot;
                }
                return _rectTransform;
            }
        }

        public override void ShowUi()
        {
            base.ShowUi();

            RectTransform.pivot = _basePivot + _moveInFrom;
            var tween = RectTransform.DOPivot(_basePivot, _moveInSpeed).SetDelay(_moveInDelay);
            tween.onComplete = OnMoveInComplete;
        }

        private void OnMoveInComplete()
        {
            OnShowUiComplete();
        }

        public override void ShowUiInstant()
        {
            base.ShowUiInstant();

            RectTransform.pivot = _basePivot;
        }

        public override void HideUi()
        {
            base.HideUi();

            RectTransform.pivot = _basePivot;
            var tween = RectTransform.DOPivot(_basePivot + _moveOutTo, _moveOutSpeed).SetDelay(_moveOutDelay);
            tween.onComplete = OnMoveOutComplete;
        }

        private void OnMoveOutComplete()
        {
            OnHideUiComplete();
        }

        public override void HideUiInstant()
        {
            base.HideUiInstant();

            RectTransform.pivot = _basePivot + _moveOutTo;
        }
    }
}