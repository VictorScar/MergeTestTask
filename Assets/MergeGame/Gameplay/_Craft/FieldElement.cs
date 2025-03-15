using System.Collections;
using System.Collections.Generic;
using MergeGame.Gameplay;
using MergeGame.Gameplay._Craft;
using UnityEngine;

public class FieldElement
{
    protected ItemGroupID _groupID;
    protected int _level;

    public FieldElement(FieldElementData data)
    {
        _groupID = data.GroupID;
        _level = data.Level;
    }

    public void Activate()
    {
        OnActivated();
    }

    protected virtual void OnActivated()
    {
       
    }
}