using DG.Tweening;
using UnityEngine;

namespace ScarFramework.UI.ViewAnimators
{
    [CreateAssetMenu(menuName = "UI/Animators/Rotate", fileName = "RotateUI")]
    public class RotateUI : UIAnimator
    {
        [SerializeField] private Vector3 startValue;
        [SerializeField] private Vector3 endValue;
        
        protected override Tween AnimateInternal()
        {
            var animationInternal = DOTween.Sequence();
            animationInternal
                .Append(_view.Rect.DORotate(startValue, duration))
                .Append(_view.Rect.DORotate(endValue, duration))
                .SetLoops(-1);

            return animationInternal;
        }

  

        protected override void OnStartAnimation()
        {
        }

        protected override void OnEndAnimation()
        {
        }

        public override UIAnimator GetInstance()
        {
            var instance = ScriptableObject.CreateInstance<RotateUI>();
            instance.duration = duration;
            instance.startValue = startValue;
            instance.endValue = endValue;

            return instance;
        }
    }
}