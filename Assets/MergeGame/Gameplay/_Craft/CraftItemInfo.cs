using UnityEngine;

namespace MergeGame.Gameplay._Craft
{
    public struct CraftItemInfo
    {
        [SerializeField] private int itemLevel;
        [SerializeField] private string itemName;
        [SerializeField] private Sprite icon;
        [SerializeField] private ItemGroupID itemGroupID;

        public int Level => itemLevel;
        public string Name => itemName;
        public Sprite Icon => icon;
        public ItemGroupID GroupID=> itemGroupID;
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