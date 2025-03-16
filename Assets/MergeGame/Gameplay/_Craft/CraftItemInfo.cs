using System;
using UnityEngine;

namespace MergeGame.Gameplay._Craft
{
    [Serializable]
    public struct CraftItemInfo
    {
        [SerializeField] private string itemName;
        [SerializeField] private Sprite icon;

        public string Name => itemName;
        public Sprite Icon => icon;
    }
}