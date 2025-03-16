using System;
using UnityEngine;

namespace MergeGame.Gameplay._Craft
{
    [CreateAssetMenu(menuName = "Configs/CraftableItems", fileName = "ItemsConfig")]
    public class CraftableItemConfig : ScriptableObject
    {
        [SerializeField] private CraftableItemByGroupData[] itemGroups;

        public bool GetItemInfo(ItemGroupID groupID, int itemLevel, out CraftableItemData itemData)
        {
            if (itemGroups != null)
            {
                foreach (var group in itemGroups)
                {
                    if (group.GroupID == groupID)
                    {
                        if (itemLevel >= 0 && itemLevel < group.Infos.Length)
                        {
                            var info = group.Infos[itemLevel];
                            itemData = new CraftableItemData{GroupID = groupID, Level = itemLevel, Icon = info.Icon, Name = info.Name};
                            return true;
                        }
                       
                    }
                }
            }

            itemData = new CraftableItemData();
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
        Packaging,
        Lighting
    }
}