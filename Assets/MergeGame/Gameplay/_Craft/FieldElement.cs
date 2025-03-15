using System.Collections;
using System.Collections.Generic;
using MergeGame.Gameplay._Craft;
using UnityEngine;

public class FieldElement
{
    protected ItemGroupID _groupID;
    protected int _level;

    public FieldElement(ItemGroupID groupID, int level = 0)
    {
        _groupID = groupID;
        _level = level;
    }


}