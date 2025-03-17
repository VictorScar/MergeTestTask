using System.Collections;
using System.Collections.Generic;
using MergeGame.Gameplay;
using MergeGame.Gameplay._Craft;
using UnityEngine;

public class FieldElement
{
    private FieldElementData _data;

    public FieldElementData Data => _data;
    
    public FieldElement(FieldElementData data)
    {
        _data = data;
    }
}