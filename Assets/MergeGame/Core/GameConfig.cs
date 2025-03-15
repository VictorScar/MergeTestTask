using MergeGame.Gameplay._Craft;
using UnityEngine;

namespace MergeGame.Core
{
    [CreateAssetMenu(menuName = "Configs/GameConfig", fileName = "GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private CraftableItemConfig itemsConfig;
        [SerializeField] private int craftFieldWidth = 10;  
        [SerializeField] private int craftFieldHeight = 10;  
        [SerializeField] private float mergeDuration = 2f;


        public CraftableItemConfig ItemsConfig => itemsConfig;
        public int FieldWidth => craftFieldWidth;
        public int FieldHeight => craftFieldHeight;
        public float MergeDuration => mergeDuration;
    }
}
