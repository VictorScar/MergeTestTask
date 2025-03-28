using System.Collections;
using System.Collections.Generic;
using MergeGame.Controllers.Handlers;
using MergeGame.Gameplay;
using MergeGame.Gameplay._Craft;
using MergeGame.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MergeGame.Controllers
{
    public class DragPartController : MonoBehaviour
    {
        private DragView _dragView;
        private CraftableItemConfig _config;
        private Coroutine _dragging;
        private GraphicRaycaster _graphicRaycaster;
        private EventSystem _eventSystem;
        private CraftFieldController _fieldController;

        public void Init(DragView dragView, CraftableItemConfig config, Canvas canvas,
            CraftFieldController fieldController)
        {
            _dragView = dragView;
            _config = config;
            _fieldController = fieldController;
            _graphicRaycaster = canvas.GetComponent<GraphicRaycaster>();
        }

        public void StartDrag(CellHandler cellHandler)
        {
            _dragView.SetItemView(cellHandler.View.Item);
            _dragging = StartCoroutine(Dragging());
        }

        public void EndDrag(CellHandler cellHandler)
        {
            var raycastResults = new List<RaycastResult>();
            var pointerEventData = new PointerEventData(_eventSystem);
            pointerEventData.position = Input.mousePosition;

            _graphicRaycaster.Raycast(pointerEventData, raycastResults);

            foreach (var result in raycastResults)
            {
                if (result.gameObject.TryGetComponent<FieldCellView>(out var targetCell))
                {
                    TryPutElement(cellHandler, targetCell);
                    break;
                }
            }

            _dragView.SetItemView(null);

            if (_dragging != null)
            {
                StopCoroutine(_dragging);
            }
        }

        private void TryPutElement(CellHandler fromCellHandler, FieldCellView targetCellView)
        {
            var targetCellHandler = _fieldController.GetItemHandler(targetCellView);

            if (fromCellHandler == targetCellHandler)
            {
                return;
            }

            var fromCellItem = fromCellHandler.Cell.FieldElement;
            var targetCellItem = targetCellHandler.Cell.FieldElement;

            if (targetCellItem != null)
            {
                if (targetCellItem.Data.IsCanMerge && targetCellItem.Data == fromCellItem.Data &&
                    !_config.IsMaxItemLevel(targetCellItem.Data))
                {
                    fromCellHandler.Cell.Clear();
                    targetCellHandler.Cell.FieldElement = new FieldElement(new FieldElementData
                    {
                        GroupID = fromCellItem.Data.GroupID, Level = fromCellItem.Data.Level + 1,
                        IsCanMerge = fromCellItem.Data.IsCanMerge
                    });
                }
                else
                {
                    fromCellHandler.Cell.FieldElement = targetCellItem;
                    targetCellHandler.Cell.FieldElement = fromCellItem;
                }
            }
            else
            {
                targetCellHandler.Cell.FieldElement = fromCellHandler.Cell.FieldElement;
                fromCellHandler.Cell.Clear();
            }
        }


        private IEnumerator Dragging()
        {
            while (true)
            {
                _dragView.Rect.position = Input.mousePosition;
                yield return null;
            }
        }
    }
}