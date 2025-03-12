using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScarFramework.UI.ViewAnimators
{
    public class FadeUI : UIAnimator
    {
        [SerializeField] private float startValue = 1;
        [SerializeField] private float endValue = 1;
        [SerializeField] private Ease ease = Ease.Linear;

        private Sequence _animation;

        public override Tween PlayAnimation()
        {
            _animation = DOTween.Sequence();
           // var sequence = DOTween.Sequence();
           _animation.Append(_view.CG.DOFade(startValue, 0.1f).SetEase(ease))
                .Append(_view.CG.DOFade(endValue, duration).SetEase(ease).OnKill(OnAnimationComplete));
            return _animation;
            
        }

        public override void Kill()
        {
            _animation.Kill();
        }

        private void OnAnimationComplete()
        {
            _view.CG.alpha = endValue;

            Debug.Log("Animation complete!");
           _view.gameObject.SetActive(endValue > 0);
        }
    }
}