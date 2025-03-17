using System;
using ScarFramework.UI.ViewAnimators;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MergeGame.UI._ItemView
{
    public class ClickableItemView : ItemView, IPointerClickHandler
    {
        [SerializeField] private UIAnimator clickAnimator;
        
        public event Action onClick;
        public void OnPointerClick(PointerEventData eventData)
        {
            clickAnimator?.PlayAnimation();
            onClick?.Invoke();
        }
    }
}
