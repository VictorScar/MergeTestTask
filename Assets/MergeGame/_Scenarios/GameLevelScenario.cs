using System.Collections;
using System.Collections.Generic;
using MergeGame.UI;
using UnityEngine;

public class GameLevelScenario : MonoBehaviour
{
    private GameScreen _gameScreen;
    private CraftFieldPanel _fieldPanel;

    public void Run()
    {
        _gameScreen = GameServiceLocator.I.UI.GetScreen<GameScreen>();
        _fieldPanel = _gameScreen.FieldPanel;
        
        _gameScreen.Show();
    }
}