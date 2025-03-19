using System.Collections.Generic;
using System.Linq;
using MergeGame.Controllers.Handlers;
using MergeGame.Core;
using MergeGame.Gameplay;
using MergeGame.Gameplay._Craft;
using MergeGame.UI;
using ScarFramework.Button;
using UnityEngine;

namespace MergeGame.Controllers
{
    public class CraftFieldController : GameplayControllerBase
    {
        [SerializeField] private ItemGroupID groupID;
        [SerializeField] private int generatorID;
        [SerializeField] private DragPartController dragPartController;
        [SerializeField] private CreateFieldElementsController createElementsController;
        [SerializeField] private int cellY;
        [SerializeField] private int cellX;

        private CraftField _field;
        private CraftFieldPanel _fieldView;
        private DragView _dragView;
        private GameConfig _config;

        private List<CellHandler> _cellHandlers = new List<CellHandler>();

        public override void Init(GameConfig config)
        {
            _config = config;
            var gameScreen = GameServiceLocator.I.UI.GetScreen<GameScreen>();
            _fieldView = gameScreen.FieldPanel;
            _dragView = gameScreen.DragView;
            dragPartController.Init(_dragView, _config.ItemsConfig, gameScreen.Canvas, this);
        }

        public void CreateField(CreateFieldData data)
        {
            _field = new CraftField(data);
            createElementsController.Init(_field, _config.ItemsConfig);

            for (int i = 0; i < data.FieldHeight; i++)
            {
                for (int j = 0; j < data.FieldWidth; j++)
                {
                    AddCell(i, j);
                }
            }
        }

        public void GenerateLevelField(FieldData data)
        {
            _field.Clear();

            if (data.GeneratorsIDs != null)
            {
                foreach (var generatorID in data.GeneratorsIDs)
                {
                    createElementsController.AddProduceElement(generatorID);
                }
            }

            if (data.StartItemsInfos != null)
            {
                foreach (var itemInfo in data.StartItemsInfos)
                {
                    for (int i = 0; i < itemInfo.ItemCount; i++)
                    {
                        createElementsController.AddCraftPartToRandomEmtyCell(itemInfo.GroupID, itemInfo.Level);
                    }
                }
            }
        }

        private void AddCell(int rowIndex, int cellIndex)
        {
            var cell = _field.AddCell(rowIndex, cellIndex);

            if (cell != null)
            {
                var cellView = _fieldView.AddCellView(rowIndex, cellIndex);
                var handler = new CellHandler(cell, cellView, _config.ItemsConfig, dragPartController,
                    createElementsController);
                _cellHandlers.Add(handler);
            }
        }

        [Button("Spawn Item")]
        public void SpawnItem()
        {
            createElementsController.AddCraftPartToEmtyCell(groupID, 0, new Vector2Int(cellY, cellX));
        }

        [Button("Spawn in cell Item")]
        public void SpawnInCellItem()
        {
            createElementsController.AddCraftPartNearCell(groupID, 0, new Vector2Int(cellY, cellX));
        }

        [Button("Spawn Generator")]
        public void SpawnGenerator()
        {
            createElementsController.AddProduceElement(generatorID);
        }

        public CellHandler GetItemHandler(FieldCellView cellView)
        {
            var handler = _cellHandlers.FirstOrDefault((h) => h.View == cellView);
            return handler;
        }
    }

    public struct CreateFieldData
    {
        public int FieldWidth;
        public int FieldHeight;
    }
}