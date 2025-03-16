using DG.Tweening;
using UnityEngine;

namespace ScarFramework.UI.ViewAnimators
{
    public abstract class UIAnimator : MonoBehaviour
    {
        [SerializeField] protected bool isShow = true;
        [SerializeField] protected float duration;
        [SerializeField] protected Ease ease = Ease.OutQuad;
        protected Sequence _animation;
        protected UIView _view;

        public virtual void Init(UIView view)
        {
            _view = view;
        }

        public Tween PlayAnimation()
        {
            OnStartAnimation();
            var viewAnimation  = AnimateInternal();
            viewAnimation.OnKill(OnEndAnimation);
            return viewAnimation;
        }

        protected abstract Tween AnimateInternal();

        public abstract void Kill();

        protected abstract void OnStartAnimation();
        protected abstract void OnEndAnimation();

    }
}
