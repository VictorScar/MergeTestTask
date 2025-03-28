using MergeGame._Scenarios;
using MergeGame.Controllers;
using ScarFramework.UI;
using UnityEngine;

namespace MergeGame.Core
{
    public class GameServiceLocator : MonoBehaviour
    {
        [SerializeField] private UISystem uiSystem;
        [SerializeField] private SceneController sceneController;
        [SerializeField] private GameplayControllersProvider gameplayControllersProvider;
        [SerializeField] private ScenariosContainer scenariosContainer;
        
        public static GameServiceLocator I { get; private set; }

        public UISystem UI => uiSystem;
        public SceneController SceneController => sceneController;
        public GameplayControllersProvider GameplayControllersProvider => gameplayControllersProvider;
        public ScenariosContainer ScenariosContainer => scenariosContainer;

        public void Init(GameConfig config)
        {
            if (I == null)
            {
                I = this;
            }
            else
            {
                Destroy(gameObject);
            }
        
            uiSystem.Init();
            sceneController.Init(config.GameSceneIndex);
            gameplayControllersProvider.Init(config);
            scenariosContainer.Init(config);
        }
    }
}
