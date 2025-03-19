using UnityEngine;
using UnityEngine.Serialization;

namespace MergeGame.Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameConfig config;
        [SerializeField] private GameServiceLocator serviceLocator;
        [SerializeField] private GameLevelScenario levelScenario;


        public void Init()
        {
            DontDestroyOnLoad(gameObject);
            serviceLocator.Init(config);
            levelScenario.Init(config);
            levelScenario.Run();
        }
    }
}