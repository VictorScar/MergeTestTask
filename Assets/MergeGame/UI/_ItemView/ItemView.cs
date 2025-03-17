using System;
using ScarFramework.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MergeGame.UI._ItemView
{
    public class ItemView : UIView, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IDragHandler,
        IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] protected Image icon;
        [SerializeField] protected TMP_Text displayName;

        public event Action onClick;
        public event Action onStartDrag;
        public event Action onEndDrag;

        public ItemViewData Data
        {
            set
            {
                icon.sprite = value.Icon;

                icon.gameObject.SetActive(icon.sprite != null);

                //displayName.text = value.Name;
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
    }

    public struct ItemViewData
    {
        public Sprite Icon;
        public string Name;
    }
}