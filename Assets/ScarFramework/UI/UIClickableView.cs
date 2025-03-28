using System;
using ScarFramework.UI.ViewAnimators;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ScarFramework.UI
{
    public class UIClickableView : UIView, IPointerClickHandler, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private UIAnimator onClickDownAnimator;
        [SerializeField] private UIAnimator onClickUpAnimator;
        public event Action<UIClickableView> onClick;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            onClick?.Invoke(this);
            Debug.Log("Click");
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            onClickUpAnimator?.PlayAnimation();
            Debug.Log("PointerUp");
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            onClickDownAnimator?.PlayAnimation();
            Debug.Log("PointerDown");
        }
    }
}
