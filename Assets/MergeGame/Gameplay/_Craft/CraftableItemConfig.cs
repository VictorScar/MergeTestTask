using System;
using UnityEngine;

namespace MergeGame.Gameplay._Craft
{
    [CreateAssetMenu(menuName = "Configs/CraftableItems", fileName = "ItemsConfig")]
    public class CraftableItemConfig : ScriptableObject
    {
        [SerializeField] private CraftableItemByGroupData[] itemGroups;

        public bool GetItemInfo(FieldElementData elementData, out CraftableItemData itemData)
        {
            return GetItemInfo(elementData.GroupID, elementData.Level, out itemData);
        }
        
        public bool GetItemInfo(ItemGroupID groupID, int itemLevel, out CraftableItemData itemData)
        {
            if (GetItemGroup(groupID, out var itemGroup))
            {
                if (itemLevel>=0 && itemLevel < itemGroup.Infos.Length)
                {
                    var info = itemGroup.Infos[itemLevel];
                    itemData = new CraftableItemData
                        { GroupID = groupID, Level = itemLevel, Icon = info.Icon, Name = info.Name };
                    return true;
                }
            }
          
            itemData = new CraftableItemData();
            return false;
        }
    
        public bool IsMaxItemLevel(FieldElementData elementData)
        {
            if (GetItemGroup(elementData.GroupID, out var itemGroup))
            {
                return elementData.Level >= itemGroup.Infos.Length-1;
            }
            
            return true;
        }

        private bool GetItemGroup(ItemGroupID groupID, out CraftableItemByGroupData itemGroup)
        {
            if (itemGroups != null)
            {
                foreach (var group in itemGroups)
                {
                    if (group.GroupID == groupID)
                    {
                        itemGroup = group;
                        return true;
                    }
                }
            }

            itemGroup = new CraftableItemByGroupData();
            return false;
            
        }
    }

    [Serializable]
    public struct CraftableItemByGroupData
    {
        [SerializeField] private ItemGroupID groupID;
        [SerializeField] private CraftItemInfo[] itemInfos;

        public ItemGroupID GroupID => groupID;
        public CraftItemInfo[] Infos => itemInfos;
    }

    public struct CraftableItemData
    {
        public int Level;
        public string Name;
        public Sprite Icon;
        public ItemGroupID GroupID;
    }

    public enum ItemGroupID
    {
        None,
        Mechanical,
        Electrical,
        BodyParts,
        Produce
    }
}