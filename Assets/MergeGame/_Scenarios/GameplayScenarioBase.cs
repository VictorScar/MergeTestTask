using System.Threading;
using MergeGame.Core;
using UnityEngine;

namespace MergeGame._Scenarios
{
    public abstract class GameplayScenarioBase : MonoBehaviour
    {
        public abstract void Init(GameConfig config);
    
        public void Run(CancellationToken gameCancellationToken)
        {
            RunInternal(gameCancellationToken);
        }

        protected abstract void RunInternal(CancellationToken gameCancellationToken);
    }
}
