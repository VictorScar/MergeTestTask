using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScarFramework.UI.ViewAnimators
{
    public class ScaleUI : UIAnimator
    {
        [SerializeField] protected float startValue = 1;
        [SerializeField] protected float endValue;
       

        protected override Tween AnimateInternal()
        {
            _animation = DOTween.Sequence();
            _animation
                .Append(_view.Rect.DOScale(endValue, duration).SetEase(ease));
            return _animation;
        }

        public override void Kill()
        {
            _animation.Kill();
        }

        protected override void OnStartAnimation()
        {
            _view.Rect.localScale = new Vector3(startValue, startValue, startValue);
            _view.gameObject.SetActive(isShow);
        }

        protected override void OnEndAnimation()
        {
            _view.Rect.localScale = new Vector3(endValue, endValue, endValue);
            _view.gameObject.SetActive(isShow);
        }
    }
}