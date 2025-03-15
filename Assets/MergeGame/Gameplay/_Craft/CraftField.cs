using MergeGame.Gameplay._Craft;
using Unity.VisualScripting;
using UnityEngine;

namespace MergeGame.Gameplay
{
    public class CraftField
    {
        private FieldCell[,] _cells;
      

        public void GenerateCraftField(CraftFieldData data)
        {
            _cells = new FieldCell[data.FieldWidth, data.FieldHeight];

            for (int y = 0; y < _cells.GetLength(0); y++)
            {
                for (int x = 0; x < _cells.GetLength(1); x++)
                {
                    _cells[y, x] = new FieldCell();
                }
            }
        }

        public bool AddElementToCell(int x, int y, FieldElementData elementData)
        {
            if (ValidateCell(x, y))
            {
                var cell = _cells[x, y];
                
                if (!cell.HasElement)
                {
                    cell.FieldElement = new FieldElement(elementData);
                    return true;
                }
            }

            return false;
        }

        private bool ValidateCell(int x, int y)
        {
            return x > -1 && x < _cells.GetLength(0) && y > -1 && y < _cells.GetLength(1);
        }
    }
    
    public struct CraftFieldData
    {
        public int FieldWidth;
        public int FieldHeight;
        public CraftItemInfo Info;
    }

    public struct FieldElementData
    {
        public ItemGroupID GroupID;
        public int Level;
        
        public FieldElementData(ItemGroupID groupID, int level)
        {
            GroupID = groupID;
            Level = level;
        }
    }
}