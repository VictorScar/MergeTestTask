using ScarFramework.UI;
using UnityEngine;

namespace MergeGame.UI
{
    public class CraftFieldPanel : UIView
    {
        [SerializeField] private RectTransform root;
        [SerializeField] private CellViewRow cellRowPrefab;
      

        public void DrawField(int fieldWidth, int fieldHeigth)
        {
            for (int i = 0; i < fieldHeigth; i++)
            {
                var row = Instantiate(cellRowPrefab, root);
            
                for (int j = 0; j < fieldWidth; j++)
                {
                    row.AddElement();
                }
            }
        }

        public void RedrawField()
        {
        
        }

        public void Clear()
        {
        
        }
    }
}