using UnityEngine;

namespace MergeGame.Core
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private GameConfig config;
        [SerializeField] private GameServiceLocator gameServiceLocator;
        
        private GameServiceLocator _serviceLocator;
        private Game _game;

        private void Start()
        {
            _serviceLocator = Instantiate(gameServiceLocator);
            _serviceLocator.Init(config);

            _game = new Game(config);
        }
    }
}