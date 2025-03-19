using MergeGame.Core;
using UnityEngine;

namespace MergeGame._Scenarios
{
    public abstract class GameplayScenarioBase : MonoBehaviour
    {
        public abstract void Init(GameConfig config);
    
        public void Run()
        {
            RunInternal();
        }

        protected abstract void RunInternal();
    }
}
