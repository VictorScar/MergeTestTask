using System;
using DG.Tweening;
using UnityEngine;

namespace ScarFramework.UI.ViewAnimators
{
    public class FadeUI : UIAnimator
    {
        [SerializeField] protected float startValue = 1;
        [SerializeField] protected float endValue = 1;

        protected override Tween AnimateInternal()
        {
            var internalAnimation = DOTween.Sequence();
            internalAnimation
                .Append(_view.CG.DOFade(endValue, duration).SetEase(ease));
            return internalAnimation;
        }
  

        protected override void OnStartAnimation()
        {
            _view.CG.alpha = startValue;
        }

        protected override void OnEndAnimation()
        {
            Debug.Log("Animation ended!");
            _view.CG.alpha = endValue;
        }
    }
}