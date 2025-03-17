using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MergeGame.Controllers.Handlers;
using MergeGame.Core;
using MergeGame.Gameplay;
using MergeGame.Gameplay._Craft;
using MergeGame.UI;
using MergeGame.UI._ItemView;
using ScarFramework.Button;
using UnityEngine;

public class CraftFieldController : MonoBehaviour
{
    [SerializeField] private ItemGroupID groupID;
    [SerializeField] private DragPartController dragPartController;

    private CraftField _field;
    private CraftFieldPanel _fieldView;
    private DragView _dragView;
    private GameConfig _config;

    private List<CellHandler> _cellHandlers = new List<CellHandler>();

    public void Init(GameConfig config)
    {
        _config = config;
        var gameScreen = GameServiceLocator.I.UI.GetScreen<GameScreen>();
        _fieldView = gameScreen.FieldPanel;
        _dragView = gameScreen.DragView;
        dragPartController.Init(_dragView, _config.ItemsConfig, gameScreen.Canvas, this);
    }

    public void CreateField(CraftFieldData data)
    {
        _field = new CraftField();

        for (int i = 0; i < data.FieldHeight; i++)
        {
            for (int j = 0; j < data.FieldWidth; j++)
            {
                AddCell(i, j);
            }
        }
    }

    private void AddCell(int rowIndex, int cellIndex)
    {
        var cell = _field.AddCell(rowIndex, cellIndex);
        var cellView = _fieldView.AddCellView(rowIndex, cellIndex);

        var handler = new CellHandler(cell, cellView, new Vector2(rowIndex, cellIndex), dragPartController);

        _cellHandlers.Add(handler);
    }

    [Button("Spawn Item")]
    public void SpawnItem()
    {
        var celX = Random.Range(0, _config.FieldWidth);
        var celY = Random.Range(0, _config.FieldHeight);

        var elementData = new FieldElementData(groupID, 0);

        var handler = _cellHandlers.Find((h) => h.Addres == new Vector2(celY, celX));

        if (_config.ItemsConfig.GetItemInfo(elementData, out var itemData))
        {
            handler.AddItem(itemData);
        }
   
    }

    public struct CraftFieldData
    {
        public int FieldWidth;
        public int FieldHeight;
        public FieldElementData[] ProduceBlocksDatas;
        public FieldElementData[] StartElementsDatas;
    }

    public CellHandler GetItemHandler(FieldCellView targetCell)
    {
        var handler = _cellHandlers.FirstOrDefault((h) => h.View == targetCell);
        return handler;
    }

    public CellHandler GetItemHandler(FieldCell cell)
    {
        var handler = _cellHandlers.FirstOrDefault((h) => h.Cell == cell);
        return handler;
    }

    public CellHandler GetItemHandler(Vector2 cellAddres)
    {
        var handler = _cellHandlers.FirstOrDefault((h) => h.Addres == cellAddres);
        return handler;
    }
}