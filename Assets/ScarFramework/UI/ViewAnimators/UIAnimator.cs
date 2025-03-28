using DG.Tweening;
using UnityEngine;

namespace ScarFramework.UI.ViewAnimators
{
    public abstract class UIAnimator : MonoBehaviour
    {
        [SerializeField] protected float duration;
        [SerializeField] protected Ease ease = Ease.OutQuad;
        
        private Sequence _animation;
        protected UIView _view;

        public void Init(UIView view)
        {
            _view = view;
            OnInit(view);
        }

        public Tween PlayAnimation()
        {
            OnStartAnimation();
            //var viewAnimation  = AnimateInternal();
            _animation  = DOTween.Sequence();
            _animation.Append(AnimateInternal().OnKill(OnEndAnimation));
            return _animation;
        }

        protected abstract Tween AnimateInternal();

        public void Kill()
        {
            _animation?.Kill();
        }

        protected abstract void OnStartAnimation();
        protected abstract void OnEndAnimation();
        
        protected virtual void OnInit(UIView view)
        {
           
        }

    }
}
