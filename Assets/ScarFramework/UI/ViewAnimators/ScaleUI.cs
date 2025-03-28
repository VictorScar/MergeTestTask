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
            var animationInternal = DOTween.Sequence();
            animationInternal
                .Append(_view.Rect.DOScale(endValue, duration).SetEase(ease));
            return animationInternal;
        }
 

        protected override void OnStartAnimation()
        {
            _view.Rect.localScale = new Vector3(startValue, startValue, startValue);
        }

        protected override void OnEndAnimation()
        {
            _view.Rect.localScale = new Vector3(endValue, endValue, endValue);
        }
    }
}