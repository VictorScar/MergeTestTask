using System.Collections;
using System.Collections.Generic;
using ScarFramework.UI;
using UnityEngine;

public class GameServiceLocator : MonoBehaviour
{
    [SerializeField] private UISystem uiSystem;
    //[SerializeField] private UISystem profile;
    //[SerializeField] private SceneController sceneController;

    public static GameServiceLocator I { get; private set; }

    public UISystem UI => uiSystem;
    
    public void Init()
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
    }
}
