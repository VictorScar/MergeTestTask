using System;
using System.Collections.Generic;
using MergeGame.Gameplay._Craft;
using UnityEngine;

namespace MergeGame.Gameplay
{
    public class CraftField
    {
        //private FieldCell[,] _cells;
        private List<FieldElementsRow> _rows = new List<FieldElementsRow>();


        public void AddCell(int rowIndex, int cellIndex)
        {
            if (rowIndex >= 0)
            {
                if (_rows.Count <= rowIndex)
                {
                    var row = new FieldElementsRow();
                    _rows.Add(row);
                }

                _rows[rowIndex].Elements.Add(new FieldCell());
            }
        }

        public void RemoveCell(int rowIndex, int cellIndex)
        {
            if (ValidateCell(rowIndex, cellIndex))
            {
                var row = _rows[rowIndex];
                row.Elements.RemoveAt(cellIndex);

                if (row.Elements.Count < 1)
                {
                    _rows.Remove(row);
                }
            }
        }


        public bool AddElementToCell(int rowIndex, int cellIndex, FieldElementData elementData)
        {
            if (TryGetCell(rowIndex, cellIndex, out var cell))
            {
                if (!cell.HasElement)
                {
                    cell.FieldElement = new FieldElement(elementData);
                    return true;
                }
            }

            return false;
        }

        public bool RemoveElementFromCell(int rowIndex, int cellIndex)
        {
            if (TryGetCell(rowIndex, cellIndex, out var cell))
            {
                if (cell.HasElement)
                {
                    cell.FieldElement = null;
                    return true;
                }
            }

            return false;
        }

        public bool TryGetCell(int rowIndex, int cellIndex, out FieldCell cell)
        {
            if (ValidateCell(rowIndex, cellIndex))
            {
                cell = _rows[rowIndex].Elements[cellIndex];
                return true;
            }

            cell = null;
            return false;
        }

        private bool ValidateCell(int rowIndex, int cellIndex)
        {
            return rowIndex > -1 && rowIndex < _rows.Count && cellIndex > -1 &&
                   cellIndex < _rows[rowIndex].Elements.Count;
        }
    }

    public class FieldElementsRow
    {
        public List<FieldCell> Elements = new List<FieldCell>();
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