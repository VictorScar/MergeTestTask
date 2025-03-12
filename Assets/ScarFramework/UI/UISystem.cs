using System.Collections.Generic;
using UnityEngine;

namespace ScarFramework.UI
{
    public class UISystem : MonoBehaviour
    {
        [SerializeField] private List<UIScreen> screens = new List<UIScreen>();

        public void Init()
        {
            foreach (var screen in screens)
            {
                screen.Init();
               
            }
        }
        
        public T GetScreen<T>() where T: UIScreen
        {
            foreach (var screen in screens)
            {
                if (screen is T tScreen)
                {
                    return tScreen;
                }
            }

            return null;
        }
    }
}
