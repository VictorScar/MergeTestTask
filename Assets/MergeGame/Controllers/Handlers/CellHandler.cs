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
        private Vector2 _address;

        public FieldCell Cell => _cell;
        public FieldCellView View => _cellView;
        public Vector2 Addres => _address;

        public CellHandler(FieldCell cell, FieldCellView cellView, Vector2 address, DragPartController dragController)
        {
            _cell = cell;
            _cellView = cellView;
            _address = address;
            _dragController = dragController;

            _cellView.onStartDrag += OnStartStartDragging;
            _cellView.onEndDrag += OnEndDragging;
            _cellView.onClick += OnClick;
        }

        public void Dispose()
        {
            _cellView.onStartDrag -= OnStartStartDragging;
            _cellView.onEndDrag -= OnEndDragging;
            _cellView.onClick -= OnClick;
        }

        public bool AddItem(CraftableItemData itemData)
        {
            if (!_cell.HasElement)
            {
                _cell.FieldElement = new CraftPart(new FieldElementData
                    { GroupID = itemData.GroupID, Level = itemData.Level });

                _cellView.AddItem(itemData.Icon);

                return true;
            }

            return false;
        }

        public bool RemoveItem()
        {
            if (_cell.HasElement)
            {
                _cell.FieldElement = null;

                _cellView.AddItem(null);

                return true;
            }

            return false;
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