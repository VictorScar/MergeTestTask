using System;
using ScarFramework.UI;
using ScarFramework.UI.ViewAnimators;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MergeGame.UI._ItemView
{
    public class ItemView : UIView, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IDragHandler,
        IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] private Image icon;
        [SerializeField] private UIView iconView;
        [SerializeField] private UIAnimator clickAnimator;
        
        public event Action onClick;
        public event Action onStartDrag;
        public event Action onEndDrag;

        protected override void OnInit()
        {
            
        }

        public ItemViewData Data
        {
            set
            {
                icon.sprite = value.Icon;
                gameObject.SetActive(icon.sprite != null);
            }
        }

        public Sprite Icon
        {
            get => icon.sprite;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
        }

        public void OnPointerExit(PointerEventData eventData)
        {
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            clickAnimator?.PlayAnimation();
            onClick?.Invoke();
            Debug.Log("OnClick");
        }

        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            icon.gameObject.SetActive(false);
            Debug.Log("OnStartDrag");
            onStartDrag?.Invoke();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            icon.gameObject.SetActive(true);
            Debug.Log("OnEndDrag");
            onEndDrag?.Invoke();
        }
    }

    public struct ItemViewData
    {
        public Sprite Icon;
    }
}