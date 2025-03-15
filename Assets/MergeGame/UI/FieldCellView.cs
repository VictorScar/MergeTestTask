using ScarFramework.UI;
using UnityEngine;
using UnityEngine.UI;

namespace MergeGame.UI
{
    public class FieldCellView : UIClickableView
    {
        [SerializeField] private Image content;

        public void SetData(Sprite icon)
        {
            content.sprite = icon;
            content.gameObject.SetActive(icon!= null);
        }

        public void Clear()
        {
            content.sprite = null;
            content.gameObject.SetActive(false);
        }
    }
}