using MergeGame.Gameplay;
using MergeGame.Gameplay._Craft;
using UnityEngine;

namespace MergeGame.Controllers
{
    public class CreateFieldElementsController : MonoBehaviour
    {
        private CraftField _field;
        private CraftableItemConfig _config;

        public void Init(CraftField field, CraftableItemConfig config)
        {
            _field = field;
            _config = config;
        }

        public void AddProduceElement(int generatorID)
        {
            if (_config.GetItemGeneratorData(generatorID, out var generatorData))
            {
                var elementData = generatorData.ElementInfo;
                _field.AddToEmptyCell(new PartGenerator(generatorData.GenerateItemData, elementData));
            }
        }


        public void AddCraftPartToEmtyCell(ItemGroupID groupID, int itemlevel)
        {
            
            if (_config.GetItemInfo(groupID, itemlevel, out var itemData))
            {
                var elementData = new FieldElementData(itemData.GroupID, itemData.Level, itemData.IsCanMerge);
                _field.AddToEmptyCell(new CraftPart(elementData));
            }
          
        }

        public void AddCraftPartNearCell(ItemGroupID groupID, int itemlevel, Vector2Int address)
        {
            if (_config.GetItemInfo(groupID, itemlevel, out var itemData))
            {
                var elementData = new FieldElementData(itemData.GroupID, itemData.Level, itemData.IsCanMerge);
                _field.AddElementToNearestEmptyCell(address.x, address.y, new CraftPart(elementData));
            }
        }
    }
}