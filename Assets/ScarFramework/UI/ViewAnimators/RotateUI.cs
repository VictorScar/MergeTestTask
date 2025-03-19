using DG.Tweening;
using UnityEngine;

namespace ScarFramework.UI.ViewAnimators
{
    public class RotateUI : UIAnimator
    {
        [SerializeField] private Vector3 startValue;
        [SerializeField] private Vector3 endValue;
        
        protected override Tween AnimateInternal()
        {
            _animation = DOTween.Sequence();
            _animation
                .Append(_view.Rect.DORotate(startValue, duration))
                .Append(_view.Rect.DORotate(endValue, duration))
                .SetLoops(-1);

            return _animation;
        }

        public override void Kill()
        {
            _animation.Kill();
        }

        protected override void OnStartAnimation()
        {
        }

        protected override void OnEndAnimation()
        {
        }
    }
}