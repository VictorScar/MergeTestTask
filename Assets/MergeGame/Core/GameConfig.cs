using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : ScriptableObject
{
   
    [SerializeField] private float mergeDuration = 2f;

   
    public float MergeDuration => mergeDuration;
}
