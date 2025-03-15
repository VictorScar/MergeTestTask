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

    public void CreateField()
    {
        _field = new CraftField();
        
        var data = new CraftFieldData();
        data.FieldWidth = _config.FieldWidth; 
        data.FieldHeight = _config.FieldHeight;
        data.Info = new CraftItemInfo();
        
        _field.GenerateCraftField(data);
        _fieldView.DrawField(data);
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
                if (_config.ItemsConfig.GetItemInfo(elementData.GroupID, elementData.Level, out var itemInfo))
                {
                    cellView.SetData(itemInfo.Icon);
                }
              
            }
        }
    }
}