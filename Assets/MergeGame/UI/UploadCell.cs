using System;
using MergeGame.Gameplay._Craft;
using ScarFramework.UI;
using UnityEngine.EventSystems;

namespace MergeGame.UI
{
    public class UploadCell : UIView, IPointerEnterHandler, IPointerExitHandler
    {
        public event Action<CraftPart> onUploadPart;

        public bool UploadItem(FieldElement fieldElement)
        {
            if (fieldElement is CraftPart part)
            {
                onUploadPart?.Invoke(part);
                return true;
            }

            return false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            
        }

        public void OnPointerExit(PointerEventData eventData)
        {
           
        }
    }
}