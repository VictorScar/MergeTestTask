using MergeGame.Controllers;
using MergeGame.Core;
using MergeGame.Gameplay._Craft;
using MergeGame.UI;
using ScarFramework.Button;
using ScarFramework.UI;
using UnityEngine;

public class GameLevelScenario : MonoBehaviour
{
    [SerializeField] private CraftFieldController fieldController;
    private GameScreen _gameScreen;
    private UIScreen _loadingScreen;
    private CraftFieldPanel _fieldPanel;
    private GameConfig _config;
    private SceneController _sceneController;

    public void Init(GameConfig config)
    {
        _config = config;
        fieldController.Init(config);
        _gameScreen = GameServiceLocator.I.UI.GetScreen<GameScreen>();
        _loadingScreen = GameServiceLocator.I.UI.GetScreen<LoadingScreen>();
        _fieldPanel = _gameScreen.FieldPanel;
        _sceneController = GameServiceLocator.I.SceneController;
    }

    public void Run()
    {
        var data = new CraftFieldController.CraftFieldData();
        data.FieldWidth = _config.FieldWidth;
        data.FieldHeight = _config.FieldHeight;
        fieldController.CreateField(data);
        _sceneController.LoadGameScene();
        _sceneController.onLoadIsCompleted += GenerateGameField;
    }

    private void GenerateGameField()
    {
        _sceneController.onLoadIsCompleted -= GenerateGameField;
        fieldController.GenerateLevelField(_config.FieldData);
        _gameScreen.Show(true);
        _loadingScreen.Hide();
    }

    [Button("Regenerate Field")]
    public void RegenerateField()
    {
        fieldController.GenerateLevelField(_config.FieldData);
    }
}