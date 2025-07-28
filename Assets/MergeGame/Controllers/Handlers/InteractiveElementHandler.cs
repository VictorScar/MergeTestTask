using MergeGame.UI;
using UnityEngine;

namespace MergeGame.Controllers.Handlers
{
    public abstract class InteractiveElementHandler
    {
        public abstract FieldCellView View { get; }
        public abstract Vector2 ID { get; }
        public abstract void Select();
        public abstract void PutElement(CellHandler element);
        
        
    }
}
