using System.Collections;
using System.Collections.Generic;
using MergeGame.UI;
using ScarFramework.UI;
using UnityEngine;

public class GameScreen : UIScreen
{
    [SerializeField] CraftFieldPanel crafetField;

    public CraftFieldPanel FieldPanel => crafetField;
}