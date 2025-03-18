using MergeGame.Gameplay;
using MergeGame.Gameplay._Craft;
using UnityEngine;

namespace MergeGame.Controllers
{
    public class CreateFieldElementsController : MonoBehaviour
    {
        private CraftField _field;

        public void Init(CraftField field)
        {
            _field = field;
        }
        
        public void AddProduceElement()
        {
            
        }
        

        public void AddCraftPartToEmtyCell(ItemGroupID groupID, int itemlevel)
        {
            if (groupID == ItemGroupID.None)
            {
                return;
            }
            
            var elementData = new FieldElementData(groupID, itemlevel);
            _field.AddToEmptyCell(new FieldElement(elementData));
            
        }

        public void AddCraftPartNearCell(ItemGroupID groupID, int itemlevel, int cellY, int cellX)
        {
            if (groupID == ItemGroupID.None)
            {
                return;
            }
            
            var elementData = new FieldElementData(groupID, itemlevel);
            _field.AddElementToNearestEmptyCell(cellY, cellX, new CraftPart(elementData));
        }
    }
}

