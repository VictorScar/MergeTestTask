using System.Collections;
using System.Collections.Generic;
using MergeGame.Core;
using MergeGame.UI;
using UnityEngine;

public class GameLevelScenario : MonoBehaviour
{
    [SerializeField] private CraftFieldController fieldController;
    private GameScreen _gameScreen;
    private CraftFieldPanel _fieldPanel;

    public void Init(GameConfig config)
    {
        fieldController.Init(config);
    }
    
    public void Run()
    {
        _gameScreen = GameServiceLocator.I.UI.GetScreen<GameScreen>();
        _fieldPanel = _gameScreen.FieldPanel;
        
        fieldController.CreateField();
        
        _gameScreen.Show();
    }


}