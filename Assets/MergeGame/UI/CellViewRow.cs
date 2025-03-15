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
    
        public void AddElement()
        {
            var cell = Instantiate(cellPrefab, root);
            
            _cells.Add(cell);
        }

        public bool GetCell(int index, FieldCellView cellView)
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
