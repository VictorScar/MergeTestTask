using System.Threading;
using MergeGame._Scenarios;

namespace MergeGame.Core
{
    public class Game
    {
        private GameConfig _config;
        private CancellationTokenSource _gameCancellation;
       
        public Game(GameConfig config)
        {
            _config = config;
            _gameCancellation = new CancellationTokenSource();
            
            StartGame();
        }

        private void StartGame()
        {
            var gameLevelScenario = GameServiceLocator.I.ScenariosContainer.GetScenario<GameLevelScenario>();

            if (gameLevelScenario)
            {
                gameLevelScenario.Run(_gameCancellation.Token);
            }
        }
    }
}