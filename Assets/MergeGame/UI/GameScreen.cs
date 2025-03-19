using System.Collections;
using System.Collections.Generic;
using MergeGame.UI;
using ScarFramework.UI;
using UnityEngine;

public class GameScreen : UIScreen
{
    [SerializeField] CraftFieldPanel crafetField;
    [SerializeField] private DragView dragView;
   
    public CraftFieldPanel FieldPanel => crafetField;
    public DragView DragView => dragView;
    
}