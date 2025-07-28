using System;
using System.Collections.Generic;
using MergeGame.Controllers;
using MergeGame.Controllers.Handlers;
using MergeGame.Gameplay._Craft;

namespace MergeGame.Gameplay
{
    public class CraftField
    {
        private FieldCell[,] _cells;
        private List<InteractiveElementHandler> _elements = new List<InteractiveElementHandler>(); 
        public int FieldHight => _cells.GetLength(0);
        public int FieldWidth => _cells.GetLength(1);
        public List<InteractiveElementHandler> Elements => _elements;

        public CraftField(CreateFieldData data)
        {
            _cells = new FieldCell[data.FieldHeight, data.FieldWidth];
        }

        /*public FieldCell AddCell(int rowIndex, int cellIndex)
        {
            if (ValidateCell(rowIndex, cellIndex))
            {
                var newCell = new FieldCell(rowIndex, cellIndex);
                _cells[rowIndex, cellIndex] = newCell;
                return newCell;
            }

            return null;
        }*/
  
        public bool AddElementToCell(int rowIndex, int cellIndex, FieldElement fieldElement)
        {
            if (TryGetCell(rowIndex, cellIndex, out var cell))
            {
                AddElementToCell(cell, fieldElement);
            }

            return false;
        }

        public bool AddElementToCell(FieldCell cell, FieldElement fieldElement)
        {
            if (cell != null)
            {
                if (!cell.HasElement)
                {
                    cell.FieldElement = fieldElement;
                    return true;
                }
            }

            return false;
        }

        public bool TryGetCell(int rowIndex, int cellIndex, out FieldCell cell)
        {
            if (ValidateCell(rowIndex, cellIndex))
            {
                cell = _cells[rowIndex, cellIndex];
                return true;
            }

            cell = null;
            return false;
        }

        private bool ValidateCell(int rowIndex, int cellIndex)
        {
            return rowIndex >= 0 && rowIndex < _cells.GetLength(0) && cellIndex >= 0 &&
                   cellIndex < _cells.GetLength(1);
        }

        public void Clear()
        {
            /*foreach (var cell in _cells)
            {
                cell.Clear();
            }*/
            foreach (var element in _elements)
            {
                if (element is CellHandler cellHandler)
                {
                    cellHandler.RemoveElement();
                }
            }
        }
    }

    [Serializable]
    public struct FieldElementData
    {
        public ItemGroupID GroupID;
        public int Level;
        public bool IsCanMerge;

        public FieldElementData(ItemGroupID groupID, int level, bool isCanMerge)
        {
            GroupID = groupID;
            Level = level;
            IsCanMerge = isCanMerge;
        }

        public static bool operator ==(FieldElementData dataA, FieldElementData dataB)
        {
            return dataA.GroupID == dataB.GroupID && dataA.Level == dataB.Level;
        }

        public static bool operator !=(FieldElementData dataA, FieldElementData dataB)
        {
            return dataA.GroupID != dataB.GroupID || dataA.Level != dataB.Level;
        }
    }
}