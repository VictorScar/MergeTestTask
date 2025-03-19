using ScarFramework.UI;
using UnityEngine;

namespace MergeGame.Core
{
    public class GameServiceLocator : MonoBehaviour
    {
        [SerializeField] private UISystem uiSystem;
        [SerializeField] private SceneController sceneController;

        public static GameServiceLocator I { get; private set; }

        public UISystem UI => uiSystem;
        public SceneController SceneController => sceneController;

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
        }
    }
}
