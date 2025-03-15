using UnityEngine;

namespace MergeGame.Gameplay._Craft
{
    [CreateAssetMenu(menuName = "Configs/CraftableItems", fileName = "ItemsConfig")]
    public class CraftableItemConfig : ScriptableObject
    {
        [SerializeField] private CraftItemInfo[] infos;

        public bool GetItemInfo(ItemGroupID groupID, int itemLevel, out CraftItemInfo itemInfo)
        {
            if (infos != null)
            {
                foreach (var info in infos)
                {
                    if (info.GroupID == groupID && info.Level == itemLevel)
                    {
                        itemInfo = info;
                        return true;
                    }
                }
            }

            itemInfo = new CraftItemInfo();
            return false;
        }
    }
}