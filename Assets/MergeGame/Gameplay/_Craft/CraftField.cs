using System;
using MergeGame.Controllers;
using MergeGame.Gameplay._Craft;

namespace MergeGame.Gameplay
{
    public class CraftField
    {
        // private List<FieldElementsRow> _rows = new List<FieldElementsRow>();

        private FieldCell[,] _cells;

        public int FieldHight => _cells.GetLength(0);
        public int FieldWidth => _cells.GetLength(1);


        public CraftField(CreateFieldData data)
        {
            _cells = new FieldCell[data.FieldHeight, data.FieldWidth];
        }

        public FieldCell AddCell(int rowIndex, int cellIndex)
        {
            if (ValidateCell(rowIndex, cellIndex))
            {
                var newCell = new FieldCell(rowIndex, cellIndex);
                _cells[rowIndex, cellIndex] = newCell;
                return newCell;
            }

            return null;
        }

        /*public bool AddToEmptyCell(FieldElement fieldElement)
        {
            if (_rows != null)
            {
                for (int i = 0; i < _rows.Count(); i++)
                {
                    for (int j = 0; j < _rows[i].Elements.Count; j++)
                    {
                        if(ValidateCell(i, j))
                        {
                            var cell = _cells(i, j);

                            if (!cell.HasElement)
                            {
                                cell.FieldElement = fieldElement;
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }*/

        /*public bool AddElementToNearestEmptyCell(int rowIndex, int cellIndex, FieldElement fieldElement)
        {
            if (FindNearestEmptyCell(rowIndex, cellIndex, out var nearestCell))
            {
                return AddElementToCell(nearestCell, fieldElement);
            }

            return false;
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

        /*public bool FindNearestEmptyCell(int rowIndex, int cellIndex, out FieldCell nearestEmptyCell)
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
        }*/

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
            foreach (var cell in _cells)
            {
                cell.Clear();
            }
        }

        /*public bool AddItemIntoRandomCell(FieldElement element)
        {
            var rowIndex = Random.Range(0, _rows.Count);
            var cellIndex = Random.Range(0, _rows[rowIndex].Elements.Count);

            return AddElementToNearestEmptyCell(rowIndex, cellIndex, element);
        }*/
    }

    /*public class FieldElementsRow
    {
        public List<FieldCell> Elements = new List<FieldCell>();
    }*/

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