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

                var cell = new FieldCell(rowIndex, _rows[rowIndex].Elements.Count);
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

        public bool AddToEmptyCell(FieldElement fieldElement)
        {
            if (_rows != null)
            {
                for (int i = 0; i < _rows.Count(); i++)
                {
                    for (int j = 0; j < _rows[i].Elements.Count; j++)
                    {
                        var cell = GetCell(i, j);

                        if (!cell.HasElement)
                        {
                            cell.FieldElement = fieldElement;
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool AddElementToNearestEmptyCell(int rowIndex, int cellIndex, FieldElement fieldElement)
        {
            if (FindNearestEmptyCell(rowIndex, cellIndex, out var nearestCell))
            {
                return AddElementToCell(nearestCell, fieldElement);
            }

            return false;
        }


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

        public bool FindNearestEmptyCell(int rowIndex, int cellIndex, out FieldCell nearestEmptyCell)
        {
            var targetPosition = new Vector2Int(rowIndex, cellIndex);
            nearestEmptyCell = null;
            var nearestSqrDistance = 100f;
            var isFound = false;

            for (int i = 0; i < _rows.Count; i++)
            {
                for (int j = 0; j < _rows[i].Elements.Count(); j++)
                {
                    if (TryGetCell(i, j, out var cell))
                    {
                        if (!cell.HasElement)
                        {
                            var newIndex = new Vector2Int(i, j);

                            var currentSqrDistance = Mathf.Abs((targetPosition - newIndex).sqrMagnitude);

                            if (currentSqrDistance < nearestSqrDistance)
                            {
                                nearestSqrDistance = currentSqrDistance;
                                nearestEmptyCell = cell;
                                isFound = true;
                            }
                        }
                    }
                }
            }

            return isFound;
          
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