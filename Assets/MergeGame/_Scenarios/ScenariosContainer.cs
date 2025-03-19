using MergeGame.Core;
using UnityEngine;

namespace MergeGame._Scenarios
{
    public class ScenariosContainer : MonoBehaviour
    {
        [SerializeField] private GameplayScenarioBase[] scenarios;

        public void Init(GameConfig config)
        {
            if (scenarios != null)
            {
                foreach (var scenario in scenarios)
                {
                    scenario.Init(config);
                }
            }
        }
        
        public T GetScenario<T>() where T : GameplayScenarioBase
        {
            if (scenarios != null)
            {
                foreach (var scenario in scenarios)
                {
                    if (scenario is T typedScenario)
                    {
                        return typedScenario;
                    }
                }
            }

            return null;
        }
    }
}
