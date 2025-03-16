using System.Collections;
using System.Collections.Generic;
using MergeGame.Gameplay;
using MergeGame.Gameplay._Craft;
using UnityEngine;

public class PartGenerator : FieldElement
{
    private CraftableItemData _partInfo;
    private CraftField _field;



    public void GenerateItem()
    {
        var part = new CraftPart(_partInfo.GroupID, _partInfo.Level);
    }

    public PartGenerator(CraftableItemData info, FieldElementData data) : base(data)
    {
        _partInfo = info;
    }
}