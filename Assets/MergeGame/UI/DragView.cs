using MergeGame.UI._ItemView;
using ScarFramework.UI;
using UnityEngine;
using UnityEngine.UI;

namespace MergeGame.UI
{
    public class DragView : UIView
    {
        [SerializeField] private Image draggingItem;

        public void SetItemView(ItemView itemView)
        {
            if (itemView != null)
            {
                var icon = itemView.Icon;
                var iconSize = itemView.Rect.rect.size;

                draggingItem.sprite = icon;

                rect.sizeDelta = iconSize;
           
            }
            else
            {
                draggingItem.sprite = null;
            }
            
            if (draggingItem.sprite)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }
    }
}