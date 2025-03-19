using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ScarFramework.UI
{
    public class UIClickableView : UIView, IPointerClickHandler
    {
        public event Action<UIClickableView> onClick;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            onClick?.Invoke(this);
            Debug.Log("Click");
        }
    }
}
