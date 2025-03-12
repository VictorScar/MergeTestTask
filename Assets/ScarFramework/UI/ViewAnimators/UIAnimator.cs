using DG.Tweening;
using UnityEngine;

namespace ScarFramework.UI.ViewAnimators
{
    public abstract class UIAnimator : MonoBehaviour
    {
        [SerializeField] protected float duration;
        protected UIView _view;

        public virtual void Init(UIView view)
        {
            _view = view;
        }
        
        public abstract Tween PlayAnimation();

        public abstract void Kill();

    }
}
