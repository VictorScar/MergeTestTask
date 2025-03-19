using MergeGame._Scenarios;
using MergeGame.Controllers;
using MergeGame.Core;
using MergeGame.UI;
using ScarFramework.Button;
using ScarFramework.UI;
using UnityEngine;

public class GameLevelScenario : GameplayScenarioBase
{
    private CraftFieldController _fieldController;
    private GameScreen _gameScreen;
    private UIScreen _loadingScreen;

    private GameConfig _config;
    private SceneController _sceneController;

    public override void Init(GameConfig config)
    {
        _config = config;
        _fieldController = GameServiceLocator.I.GameplayControllersProvider.GetController<CraftFieldController>();
        _fieldController.Init(config);
        _gameScreen = GameServiceLocator.I.UI.GetScreen<GameScreen>();
        _loadingScreen = GameServiceLocator.I.UI.GetScreen<LoadingScreen>();
        _sceneController = GameServiceLocator.I.SceneController;
    }
    
    [Button("Regenerate Field")]
    public void RegenerateField()
    {
        if (GetRandomFieldData(out var fieldData))
        {
            _fieldController.GenerateLevelField(fieldData);
        }
    }

    protected override void RunInternal()
    {
        var data = new CreateFieldData();
        data.FieldWidth = _config.FieldWidth;
        data.FieldHeight = _config.FieldHeight;
        _fieldController.CreateField(data);
        _sceneController.LoadGameScene();
        _sceneController.onLoadIsCompleted += GenerateGameField;
    }

    private void GenerateGameField()
    {
        _sceneController.onLoadIsCompleted -= GenerateGameField;

        if (GetRandomFieldData(out var fieldData))
        {
            _fieldController.GenerateLevelField(fieldData);
        }
        
        _gameScreen.Show(true);
        _loadingScreen.Hide();
    }

    private bool GetRandomFieldData(out FieldData fieldData)
    {
        var fieldDatas = _config.FieldDatas;
        
        if (fieldDatas != null && fieldDatas.Length > 0)
        {
            var index = Random.Range(0, fieldDatas.Length);
            fieldData = fieldDatas[index];
            return true;
        }

        fieldData = new FieldData();
        return false;
    }

}