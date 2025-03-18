using System;
using UnityEngine;

namespace MergeGame.Gameplay._Craft
{
    [Serializable]
    public struct ItemInfo
    {
        [SerializeField] private string itemName;
        [SerializeField] private Sprite icon;
        [SerializeField] private bool isCanMerge;

        public string Name => itemName;
        public Sprite Icon => icon;
        public bool IsCanMerge => isCanMerge;
    }
}