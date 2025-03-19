using MergeGame._Scenarios;
using MergeGame.Controllers;
using MergeGame.Core;
using MergeGame.UI;
using ScarFramework.Button;
using ScarFramework.UI;

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
        _fieldController.GenerateLevelField(_config.FieldData);
        _gameScreen.Show(true);
        _loadingScreen.Hide();
    }

    [Button("Regenerate Field")]
    public void RegenerateField()
    {
        _fieldController.GenerateLevelField(_config.FieldData);
    }
}