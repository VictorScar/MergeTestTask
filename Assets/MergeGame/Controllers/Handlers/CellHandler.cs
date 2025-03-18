using MergeGame.Gameplay;
using MergeGame.Gameplay._Craft;
using MergeGame.UI;
using MergeGame.UI._ItemView;
using UnityEngine;

namespace MergeGame.Controllers.Handlers
{
    public class CellHandler
    {
        private FieldCell _cell;
        private FieldCellView _cellView;
        private DragPartController _dragController;

        public FieldCell Cell => _cell;
        public FieldCellView View => _cellView;
        private CraftableItemConfig _config;

        public CellHandler(FieldCell cell, FieldCellView cellView, CraftableItemConfig config,
            DragPartController dragController)
        {
            _cell = cell;
            _cellView = cellView;
            _config = config;
            _dragController = dragController;

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
 

        private void OnItemAdded(FieldElement item)
        {
            if (_config.GetItemInfo(item.Data, out var itemData))
            {
                _cellView.AddItem(itemData.Icon);
            }
        }

        private void OnItemRemoved()
        {
            _cellView.AddItem(null);
        }

        private void OnStartStartDragging()
        {
            _dragController.StartDrag(this);
        }

        private void OnEndDragging()
        {
            _dragController.EndDrag(this);
        }

        private void OnClick()
        {
        }
    }
}