using System;
using UnityEngine.EventSystems;

namespace MergeGame.UI._ItemView
{
    public class DragableItemView : ItemView, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public event Action onBeginDragging; 
        public event Action onEndDragging; 
        
        
        public void OnDrag(PointerEventData eventData)
        {
            
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            onBeginDragging?.Invoke();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            onEndDragging?.Invoke();
        }
    }
}
