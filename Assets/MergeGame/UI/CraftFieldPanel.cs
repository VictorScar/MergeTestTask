using System.Collections.Generic;
using MergeGame.Gameplay;
using ScarFramework.UI;
using UnityEngine;

namespace MergeGame.UI
{
    public class CraftFieldPanel : UIView
    {
        [SerializeField] private RectTransform root;
        [SerializeField] private CellViewRow cellRowPrefab;

        private List<CellViewRow> _rows = new List<CellViewRow>();


   
        private void AddCellsRow()
        {
            var row = Instantiate(cellRowPrefab, root);
            _rows.Add(row);
        }

        public FieldCellView AddCellView(int rowNumber, int cellIndex)
        {
            if (_rows.Count <= rowNumber)
            {
                AddCellsRow();
            }

            return _rows[rowNumber].AddCell();
        }

        public bool GetCell(int celX, int celY, out FieldCellView cell)
        {
            if (celY >= 0 && celY < _rows.Count)
            {
                var row = _rows[celY];

                if (row.GetCell(celX, out var cellView))
                {
                    cell = cellView;
                    return true;
                }
            }

            cell = null;
            return false;
        }
    }
}