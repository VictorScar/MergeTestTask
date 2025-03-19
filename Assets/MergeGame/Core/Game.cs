using UnityEngine;
using UnityEngine.Serialization;

namespace MergeGame.Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameConfig config;
        [SerializeField] private GameServiceLocator serviceLocator;
      
        public void Init()
        {
            DontDestroyOnLoad(gameObject);
            serviceLocator.Init(config);
            
            serviceLocator.ScenariosContainer.GetScenario<GameLevelScenario>().Run();
        }
    }
}