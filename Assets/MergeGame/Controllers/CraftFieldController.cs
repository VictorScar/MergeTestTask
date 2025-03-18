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
    [SerializeField] private int cellY;
    [SerializeField] private int cellX;

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

        var handler = new CellHandler(cell, cellView, _config.ItemsConfig, dragPartController);

        _cellHandlers.Add(handler);
    }

    [Button("Spawn Item")]
    public void SpawnItem()
    {
        var elementData = new FieldElementData(groupID, 0);
        _field.AddToEmptyCell(elementData);
    }
    
    [Button("Spawn in cell Item")]
    public void SpawnInCellItem()
    {
        
        var elementData = new FieldElementData(groupID, 0);

      
        _field.AddElementToNearestEmptyCell(cellY, cellX, elementData);
        
    }

    public struct CraftFieldData
    {
        public int FieldWidth;
        public int FieldHeight;
        public FieldElementData[] ProduceBlocksDatas;
        public FieldElementData[] StartElementsDatas;
    }

    public CellHandler GetItemHandler(FieldCellView cellView)
    {
        var handler = _cellHandlers.FirstOrDefault((h) => h.View == cellView);
        return handler;
    }

    public CellHandler GetItemHandler(FieldCell cell)
    {
        var handler = _cellHandlers.FirstOrDefault((h) => h.Cell == cell);
        return handler;
    }

    /*public CellHandler GetItemHandler(Vector2 cellAddres)
    {
        var handler = _cellHandlers.FirstOrDefault((h) => h.Addres == cellAddres);
        return handler;
    }*/
}