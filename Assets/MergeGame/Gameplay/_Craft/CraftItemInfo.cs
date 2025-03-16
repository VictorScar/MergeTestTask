using System;
using UnityEngine;

namespace MergeGame.Gameplay._Craft
{
    [Serializable]
    public struct CraftItemInfo
    {
       // [SerializeField] private int itemLevel;
        [SerializeField] private string itemName;
        [SerializeField] private Sprite icon;
        //[SerializeField] private ItemGroupID itemGroupID;

       // public int Level => itemLevel;
        public string Name => itemName;
        public Sprite Icon => icon;
        //public ItemGroupID GroupID=> itemGroupID;
    }


}