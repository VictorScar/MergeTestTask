using System;
using ScarFramework.UI;
using ScarFramework.UI.ViewAnimators;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MergeGame.UI._ItemView
{
    public class ItemView : UIView, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IDragHandler,
        IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Image icon;
        [SerializeField] private UIAnimator pointerDownAnimator;
        [SerializeField] private UIAnimator pointerUpAnimator;

        public event Action onClick;
        public event Action onStartDrag;
        public event Action onEndDrag;

        protected override void OnInit()
        {
            //pointerDownAnimator = pointerDownAnimator.GetInstance();
            pointerDownAnimator?.Init(this);
            //pointerUpAnimator = pointerUpAnimator.GetInstance();
            pointerUpAnimator?.Init(this);
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
            onClick?.Invoke();
        }

        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            icon.gameObject.SetActive(false);
            onStartDrag?.Invoke();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            icon.gameObject.SetActive(true);
            onEndDrag?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            pointerDownAnimator?.PlayAnimation(this);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            pointerUpAnimator?.PlayAnimation(this);
        }
    }

    public struct ItemViewData
    {
        public Sprite Icon;
    }
}