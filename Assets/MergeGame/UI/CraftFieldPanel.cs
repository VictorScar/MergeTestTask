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


        public void RedrawField()
        {
        
        }

        public void Clear()
        {
        
        }

        public void DrawField(CraftFieldData data)
        {
            for (int i = 0; i < data.FieldHeight; i++)
            {
                var row = Instantiate(cellRowPrefab, root);
            
                for (int j = 0; j < data.FieldWidth; j++)
                {
                    row.AddElement();
                }
                
                _rows.Add(row);
            }
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