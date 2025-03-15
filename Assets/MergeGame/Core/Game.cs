using System.Collections;
using System.Collections.Generic;
using MergeGame.Core;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameConfig config;
    [SerializeField] private GameServiceLocator serviceLocator;
    [SerializeField] private GameLevelScenario levelScenario;
    
    public void Init()
    {
        serviceLocator.Init();
        levelScenario.Init(config);
        levelScenario.Run();
    }
}