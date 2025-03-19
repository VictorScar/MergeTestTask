using MergeGame.Core;
using UnityEngine;

namespace MergeGame.Controllers
{
    public class GameplayControllersProvider : MonoBehaviour
    {
        [SerializeField] private GameplayControllerBase[] controllers;

        public void Init(GameConfig config)
        {
            if (controllers != null)
            {
                foreach (var controller in controllers)
                {
                    controller.Init(config);
                }
            }
        }
        
        public T GetController<T>() where T : GameplayControllerBase
        {
            if (controllers != null)
            {
                foreach (var controller in controllers)
                {
                    if (controller is T typedController)
                    {
                        return typedController;
                    }
                }
            }

            return null;
        }
    }
}