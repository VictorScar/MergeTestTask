using System.Collections;
using System.Collections.Generic;
using MergeGame.Core;
using MergeGame.Gameplay;
using MergeGame.Gameplay._Craft;
using MergeGame.UI;
using ScarFramework.Button;
using UnityEngine;

public class CraftFieldController : MonoBehaviour
{
    [SerializeField] private ItemGroupID groupID;

    private CraftField _field;
    private CraftFieldPanel _fieldView;
    private GameConfig _config;

    public void Init(GameConfig config)
    {
        _config = config;
        _fieldView = GameServiceLocator.I.UI.GetScreen<GameScreen>().FieldPanel;
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
        _field.AddCell(rowIndex, cellIndex);
        _fieldView.AddCellView(rowIndex, cellIndex);
    }

    [Button("Spawn Item")]
    public void SpawnItem()
    {
        var celX = Random.Range(0, _config.FieldWidth);
        var celY = Random.Range(0, _config.FieldHeight);

        var elementData = new FieldElementData(groupID, 0);

        if (_field.AddElementToCell(celX, celY, elementData))
        {
            if (_fieldView.GetCell(celX, celY, out var cellView))
            {
                if (_config.ItemsConfig.GetItemInfo(elementData.GroupID, elementData.Level, out var itemData))
                {
                    cellView.SetData(itemData.Icon);
                }
            }
        }
    }

    public struct CraftFieldData
    {
        public int FieldWidth;
        public int FieldHeight;
        public CraftItemInfo Info;
    }

    public class CellHandler
    {
        private FieldCell _cell;
        private FieldCellView _cellView;

        public CellHandler(FieldCell cell, FieldCellView cellView)
        {
            _cell = cell;
            _cellView = cellView;
        }
    }
}