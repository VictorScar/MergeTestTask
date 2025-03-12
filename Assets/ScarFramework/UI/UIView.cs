using DG.Tweening;
using ScarFramework.Button;
using ScarFramework.UI.ViewAnimators;
using UnityEngine;

namespace ScarFramework.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(RectTransform))]
    public class UIView : MonoBehaviour
    {
        [Header("Default References")] [SerializeField]
        private RectTransform rect;

        [SerializeField] private CanvasGroup cg;

        [Header("Animations")] [SerializeField]
        private UIAnimator showInAnimator;
      
        [SerializeField] private UIAnimator hideInAnimator;
    

        public RectTransform Rect => rect;
        public CanvasGroup CG => cg;

        public void Init()
        {
            if (!rect)
            {
                GetComponent<RectTransform>();
            }

            if (!cg)
            {
                cg = GetComponent<CanvasGroup>();
            }
            
            showInAnimator?.Init(this);
           
            hideInAnimator?.Init(this);
          

            OnInit();
        }

        [Button("Show")]
        public void DebugShow()
        {
            Show();
        }
        
        [Button("Hide")]
        public void DebugHide()
        {
            Hide();
        }
        
        [Button("Init")]
        public void DebugInit()
        {
            Init();
        }
        
        [Button("Kill")]
        public void DebugKill()
        {
            showInAnimator?.Kill();
            hideInAnimator?.Kill();
        }
        
        public void Show(bool immediately = false)
        {
            if (!immediately)
            {
                gameObject.SetActive(true);
                showInAnimator?.PlayAnimation().OnKill(OnShow);

            }
            else
            {
                gameObject.SetActive(true);
                OnShow();
            }
           
        }
   
        public void Hide(bool immediately = false)
        {
            if (!immediately)
            {
                hideInAnimator?.PlayAnimation().OnKill(OnHide);
                
            }
            else
            {
                gameObject.SetActive(false);
                OnHide();
            }
        }

        protected virtual void OnInit()
        {
        }

        protected virtual void OnShow()
        {
            Debug.Log("OnShow");
        }

        protected virtual void OnHide()
        {
            Debug.Log("OnHide");
        }
    }
}