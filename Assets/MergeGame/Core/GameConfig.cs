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
        [SerializeField] private FieldData[] fieldDatas;
        [SerializeField] private int gameSceneIndex = 1;

        public CraftableItemConfig ItemsConfig => itemsConfig;
        public int FieldWidth => craftFieldWidth;
        public int FieldHeight => craftFieldHeight;
        public FieldData[] FieldDatas => fieldDatas;
        public int GameSceneIndex => gameSceneIndex;
    }
}