using System;
using UnityEngine;

namespace MergeGame._ProfileData
{
    [Serializable]
    public struct ResourceData
    {
        [SerializeField] private ResourceID id;
        [SerializeField] private Sprite icon;
        [SerializeField] private string resourceName;

        public ResourceID ID => id;
        public Sprite Icon => icon;
        public string Name => resourceName;
    }
}
