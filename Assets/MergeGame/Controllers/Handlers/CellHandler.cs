using MergeGame.Gameplay;
using MergeGame.Gameplay._Craft;
using MergeGame.UI;
using MergeGame.UI._ItemView;
using UnityEngine;

namespace MergeGame.Controllers.Handlers
{
    public class CellHandler : InteractiveElementHandler
    {
        private FieldCell _cell;
        private FieldCellView _cellView;
        private DragPartController _dragController;
        private CreateFieldElementsController _createElementController;

        //public FieldCell Cell => _cell;
        public FieldElement Element
        {
            get => _cell.FieldElement;
            set => _cell.FieldElement = value;
        }

        public override FieldCellView View => _cellView;
        public override Vector2 ID { get; }
        private CraftableItemConfig _config;

        public ItemGroupID GroupID
        {
            get
            {
                if (_cell != null && _cell.FieldElement != null)
                {
                    return _cell.FieldElement.Data.GroupID;
                }

                return ItemGroupID.None;
            }
        }

        public int ElementLevel
        {
            get
            {
                if (_cell != null && _cell.FieldElement != null)
                {
                    return _cell.FieldElement.Data.Level;
                }

                return -1;
            }
        }

        public CellHandler(FieldCell cell, FieldCellView cellView, CraftableItemConfig config,
            DragPartController dragController, CreateFieldElementsController createElementController)
        {
            _cell = cell;
            _cellView = cellView;
            _config = config;
            _dragController = dragController;
            _createElementController = createElementController;

            _cellView.onStartDrag += OnStartStartDragging;
            _cellView.onEndDrag += OnEndDragging;
            _cellView.onClick += OnClick;
            _cell.onItemAdded += OnItemAdded;
            _cell.onItemRemoved += OnItemRemoved;
        }

        public void Dispose()
        {
            _cellView.onStartDrag -= OnStartStartDragging;
            _cellView.onEndDrag -= OnEndDragging;
            _cellView.onClick -= OnClick;
            _cell.onItemAdded -= OnItemAdded;
            _cell.onItemRemoved -= OnItemRemoved;
        }

        public override void PutElement(CellHandler sourceHandler)
        {
            if (sourceHandler == this)
            {
                return;
            }

            var fromCellItem = sourceHandler.Element;
            var targetCellItem = Element;

            if (targetCellItem != null)
            {
                if (targetCellItem.Data.IsCanMerge && targetCellItem.Data == fromCellItem.Data &&
                    !_config.IsMaxItemLevel(targetCellItem.Data))
                {
                    sourceHandler.RemoveElement();
                    Element = new FieldElement(new FieldElementData
                    {
                        GroupID = fromCellItem.Data.GroupID, Level = fromCellItem.Data.Level + 1,
                        IsCanMerge = fromCellItem.Data.IsCanMerge
                    });
                }
                else
                {
                    sourceHandler.Element = targetCellItem;
                    Element = fromCellItem;
                }
            }
            else
            {
                Element = sourceHandler.Element;
                sourceHandler.RemoveElement();
            }
        }

        public void RemoveElement()
        {
            _cell.Clear();
        }
        
        private void OnItemAdded(FieldElement item)
        {
            if (_config.GetItemInfo(item.Data, out var itemData))
            {
                _cellView.SetIcon(itemData.Icon);
            }
        }

        private void OnItemRemoved()
        {
            _cellView.SetIcon(null);
        }

        private void OnStartStartDragging()
        {
            _cellView.Item.IconIsVisible = false;
            _dragController.StartDrag(this);
        }

        private void OnEndDragging()
        {
            _cellView.Item.IconIsVisible = true;
            _dragController.EndDrag(this);
        }

        private void OnClick()
        {
            if (_cell.FieldElement is PartGenerator partGenerator)
            {
                var newItemData = partGenerator.GeneratePartData;
                _createElementController.AddCraftPartNearCell(newItemData.GroupID, newItemData.Level, _cell.Address);
            }
        }

        public override void Select()
        {
        }

   
    }
}