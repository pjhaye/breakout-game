using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class DelayCommand : Command
    {
        private readonly MonoBehaviour _coroutineTarget;
        private readonly float _duration;

        public DelayCommand(float duration, MonoBehaviour coroutineTarget)
        {
            _duration = duration;
            _coroutineTarget = coroutineTarget;
        }

        public override void Execute()
        {
            _coroutineTarget.StartCoroutine(Delay());
        }

        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(_duration);
            OnComplete();
        }

        public override void OnComplete()
        {
            base.OnComplete();
        }
    }
}