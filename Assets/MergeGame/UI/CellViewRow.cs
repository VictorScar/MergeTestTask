using System.Collections.Generic;
using ScarFramework.UI;
using UnityEngine;

namespace MergeGame.UI
{
    public class CellViewRow : UIView
    {
        [SerializeField] private RectTransform root;
        [SerializeField] private FieldCellView cellPrefab;

        private List<FieldCellView> _cells = new List<FieldCellView>();
    
        public FieldCellView AddCell()
        {
            var cell = Instantiate(cellPrefab, root);
            cell.Init();
            _cells.Add(cell);

            return cell;
        }

        public void RemoveCell(int cellIndex)
        {
            if (cellIndex >= 0 && cellIndex < _cells.Count)
            {
                var cell = _cells[cellIndex];
                _cells.Remove(cell);
                Destroy(cell);
            }
            
        }

        public bool GetCell(int index, out FieldCellView cellView)
        {
            if (index >= 0 && index < _cells.Count)
            {
                cellView =  _cells[index];
                return true;
            }

            cellView = null;
            return false;
        }
    }
}
