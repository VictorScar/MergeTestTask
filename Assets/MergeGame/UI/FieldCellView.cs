using System;
using MergeGame.UI._ItemView;
using ScarFramework.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MergeGame.UI
{
    public class FieldCellView : UIView
    {
        //[SerializeField] private RectTransform content;
        [SerializeField] private Image highlight;
        [SerializeField]private ItemView itemView;
        
        public event Action onStartDrag;
        public event Action onEndDrag;
        public event Action onClick;

        public ItemView Item => itemView;

        public void Init()
        {
            itemView.onClick += OnClick;
            itemView.onStartDrag += OnDrag;
            itemView.onEndDrag += OnEndDrag;
        }

        private void OnDestroy()
        {
            itemView.onClick -= OnClick;
            itemView.onStartDrag -= OnDrag;
            itemView.onEndDrag -= OnEndDrag;
        }

        public void AddItem(Sprite itemIcon)
        {
            itemView.Data = new ItemViewData { Icon = itemIcon };
        }

        public void RemoveItem()
        {
            itemView.Data = new ItemViewData { Icon = null };
        }

        public void HighlightCell(bool isHighlighting)
        {
            highlight.gameObject.SetActive(isHighlighting);
        }

        private void OnDrag()
        {
            onStartDrag?.Invoke();
        }

        private void OnEndDrag()
        {
            onEndDrag?.Invoke();
        }

        private void OnClick()
        {
            onClick?.Invoke();
        }
    }
}