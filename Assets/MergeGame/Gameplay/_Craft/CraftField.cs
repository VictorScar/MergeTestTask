using System;
using System.Collections.Generic;
using System.Linq;
using MergeGame.Gameplay._Craft;
using UnityEngine;

namespace MergeGame.Gameplay
{
    public class CraftField
    {
        private List<FieldElementsRow> _rows = new List<FieldElementsRow>();

        public FieldCell AddCell(int rowIndex, int cellIndex)
        {
            if (rowIndex >= 0)
            {
                if (_rows.Count <= rowIndex)
                {
                    var row = new FieldElementsRow();
                    _rows.Add(row);
                }

                var cell = new FieldCell();
                _rows[rowIndex].Elements.Add(cell);

                return cell;
            }

            return null;
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

        public bool AddElementToNearestEmptyCell(int rowIndex, int cellIndex, FieldElementData elementData)
        {
            if (FindNearestEmptyCell(rowIndex, cellIndex, out var nearestCell))
            {
                return AddElementToCell(nearestCell, elementData);
            }

            return false;
        }
        

        public bool AddElementToCell(int rowIndex, int cellIndex, FieldElementData elementData)
        {
            if (TryGetCell(rowIndex, cellIndex, out var cell))
            {
                AddElementToCell(cell, elementData);
            }

            return false;
        }
        
        public bool AddElementToCell(FieldCell cell, FieldElementData elementData)
        {
            if (cell!=null)
            {
                if (!cell.HasElement)
                {
                    cell.FieldElement = new FieldElement(elementData);
                    return true;
                }
            }

            return false;
        }

        public bool FindNearestEmptyCell(int rowIndex, int cellIndex, out FieldCell nearestEmptyCell)
        {
            /*var hasNotEmptyCell = false;
            var i = 1;
            var forward = new Vector2(0, 1);
            var backward = new Vector2(0, -1);
            var top = new Vector2(1, 0);
            var down = new Vector2(-1, 0);
            var topForward = new Vector2(1, 1);
            var downForward = new Vector2(-1, 1);
            var topBackward = new Vector2(1, -1);
            var downBackward = new Vector2(-1, -1);
            
            while (!hasNotEmptyCell)
            {
                hasNotEmptyCell = true;
                
                TryGetCell
            }*/
            List<Vector2Int> emptyCellsIndexes = new List<Vector2Int>();

            for (int i = 0; i < _rows.Count; i++)
            {
                for (int j = 0; j < _rows[0].Elements.Count; j++)
                {
                    var cell = GetCell(i, j);

                    if (!cell.HasElement)
                    {
                        emptyCellsIndexes.Add(new Vector2Int(i, j));
                    }
                }
            }

            if (emptyCellsIndexes.Count > 0)
            {
                var sortedCellIndexes = emptyCellsIndexes.OrderByDescending((index) =>
                    new Vector2(Mathf.Abs(index.y - rowIndex),
                        Mathf.Abs((index.x - cellIndex)))).ToArray();

                var nearestCellAdress = sortedCellIndexes[0];

                nearestEmptyCell = GetCell(nearestCellAdress.y, nearestCellAdress.x);
                return true;
            }
            else
            {
                nearestEmptyCell = null;
                return false;
            }
            
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
                cell = GetCell(rowIndex, cellIndex);
                return true;
            }

            cell = null;
            return false;
        }

        private FieldCell GetCell(int rowIndex, int cellIndex)
        {
            return _rows[rowIndex].Elements[cellIndex];
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