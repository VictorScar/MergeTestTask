using System.Collections;
using System.Collections.Generic;
using MergeGame.Gameplay;
using MergeGame.Gameplay._Craft;
using UnityEngine;

public class PartGenerator : FieldElement
{
    private FieldElementData _partInfo;
    private CraftField _field;

    public void GenerateItem()
    {
        var part = new CraftPart(_partInfo);
    }

    public PartGenerator(FieldElementData craftableItemData, FieldElementData data) : base(data)
    {
        _partInfo = craftableItemData;
    }
}