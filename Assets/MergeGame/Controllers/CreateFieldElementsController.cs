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
                var newItemGenerator = new PartGenerator(generatorData.GenerateItemData, elementData);

                if (GetRandomEmptyCellAddress(out var address))
                {
                    AddElementToEmtyCell(newItemGenerator, address);
                }
            }
        }

        public void AddCraftPartToEmtyCell(ItemGroupID groupID, int itemlevel, Vector2Int cellAdress)
        {
            if (_config.GetItemInfo(groupID, itemlevel, out var itemData))
            {
                var elementData = new FieldElementData(itemData.GroupID, itemData.Level, itemData.IsCanMerge);
                AddElementToEmtyCell(new CraftPart(elementData), cellAdress);
            }
        }

        private void AddElementToEmtyCell(FieldElement fieldElement, Vector2Int cellAdress)
        {
            _field.AddElementToCell(cellAdress.x, cellAdress.y, fieldElement);
        }

        public void AddCraftPartToRandomEmtyCell(ItemGroupID groupID, int itemlevel)
        {
            if (GetRandomEmptyCellAddress(out var address))
            {
                AddCraftPartToEmtyCell(groupID, itemlevel, address);
            }
        }

        public void AddCraftPartNearCell(ItemGroupID groupID, int itemlevel, Vector2Int targetAddress)
        {
            if (TryGetNearestEmtyCell(targetAddress.x, targetAddress.y, out var address))
            {
                AddCraftPartToEmtyCell(groupID, itemlevel, address);
            }
        }

        private bool GetRandomEmptyCellAddress(out Vector2Int address)
        {
            var randomAddress = new Vector2Int(Random.Range(0, _field.FieldHight), Random.Range(0, _field.FieldWidth));

            if (TryGetNearestEmtyCell(randomAddress.x, randomAddress.y, out var nearestEmptyCellAddress))
            {
                address = nearestEmptyCellAddress;
                return true;
            }

            address = Vector2Int.zero;
            return false;
        }

        private bool TryGetNearestEmtyCell(int rowIndex, int cellIndex, out Vector2Int nearestEmptyCellAddress)
        {
            var targetPosition = new Vector2Int(rowIndex, cellIndex);
            nearestEmptyCellAddress = Vector2Int.zero;
            var nearestSqrDistance = 100f;
            var isFound = false;

            for (int i = 0; i < _field.FieldHight; i++)
            {
                for (int j = 0; j < _field.FieldWidth; j++)
                {
                    if (_field.TryGetCell(i, j, out var cell))
                    {
                        if (!cell.HasElement)
                        {
                            var newIndex = new Vector2Int(i, j);

                            var currentSqrDistance = Mathf.Abs((targetPosition - newIndex).sqrMagnitude);

                            if (currentSqrDistance < nearestSqrDistance)
                            {
                                nearestSqrDistance = currentSqrDistance;
                                nearestEmptyCellAddress = newIndex;
                                isFound = true;
                            }
                        }
                    }
                }
            }

            return isFound;
        }
    }
}