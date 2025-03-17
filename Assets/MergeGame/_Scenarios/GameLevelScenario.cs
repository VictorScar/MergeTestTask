using MergeGame.Core;
using MergeGame.Gameplay._Craft;
using MergeGame.UI;
using UnityEngine;

public class GameLevelScenario : MonoBehaviour
{
    [SerializeField] private CraftFieldController fieldController;
    private GameScreen _gameScreen;
    private CraftFieldPanel _fieldPanel;
    private GameConfig _config;

    public void Init(GameConfig config)
    {
        _config = config;
        fieldController.Init(config);
    }

    public void Run()
    {
        _gameScreen = GameServiceLocator.I.UI.GetScreen<GameScreen>();
        _fieldPanel = _gameScreen.FieldPanel;

        var data = new CraftFieldController.CraftFieldData();
        data.FieldWidth = _config.FieldWidth;
        data.FieldHeight = _config.FieldHeight;


        fieldController.CreateField(data);

        _gameScreen.Show();
    }
}