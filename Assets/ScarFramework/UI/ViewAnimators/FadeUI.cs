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
            _animation = DOTween.Sequence();
            _animation
                .Append(_view.CG.DOFade(endValue, duration).SetEase(ease));
            return _animation;
        }

        public override void Kill()
        {
            _animation.Kill();
        }

        protected override void OnStartAnimation()
        {
            _view.CG.alpha = startValue;
            
            if (isShow)
            {
                _view.gameObject.SetActive(isShow);
            }
           
        }

        protected override void OnEndAnimation()
        {
            _view.CG.alpha = endValue;

            Debug.Log("Animation complete!");
            _view.gameObject.SetActive(endValue > 0);
        }
    }
}