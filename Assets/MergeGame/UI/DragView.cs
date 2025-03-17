using System.Collections;
using System.Collections.Generic;
using ScarFramework.UI;
using UnityEngine;
using UnityEngine.UI;

public class DragView : UIView
{
    [SerializeField] private Image draggingItem;

    public void SetItemView(Sprite itemIcon)
    {
        draggingItem.sprite = itemIcon;

        if (itemIcon)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
}