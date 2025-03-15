using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boot : MonoBehaviour
{
   [SerializeField] private Game game;
    
    private void Start()
    {
       game.Init();
    }
}
