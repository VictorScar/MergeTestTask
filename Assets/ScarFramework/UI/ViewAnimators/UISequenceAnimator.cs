using DG.Tweening;
using UnityEngine;

namespace ScarFramework.UI.ViewAnimators
{
    [CreateAssetMenu(menuName = "UI/Animators/Sequence", fileName = "SequenceUI")]
    public class UISequenceAnimator : UIAnimator
    {
        [SerializeField] private UIAnimator[] animators;

        protected override void OnInit(UIView view)
        {
            if (animators != null)
            {
                foreach (var animator in animators)
                {
                    animator.Init(view);
                }
            }
        }

        public override UIAnimator GetInstance()
        {
            throw new System.NotImplementedException();
        }

        protected override Tween AnimateInternal()
        {
            if (animators != null)
            {
                var animationInternal = DOTween.Sequence();

                foreach (var animator in animators)
                {
                    animationInternal.Append(animator.PlayAnimation());
                }

                animationInternal.Play();
              
                return animationInternal;
            }

            return null;
        }

        protected override void OnStartAnimation()
        {
        
        }

        protected override void OnEndAnimation()
        {
           // _view.Rect.localScale = Vector3.one;
        }
    }
}
