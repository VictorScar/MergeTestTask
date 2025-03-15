using System.Collections;
using System.Collections.Generic;
using MergeGame.Gameplay;
using MergeGame.Gameplay._Craft;
using UnityEngine;

public class PartGenerator : FieldElement
{
    private CraftItemInfo _partInfo;
    private CraftField _field;


    public PartGenerator(CraftItemInfo info, ItemGroupID groupID,  int level = 0) : base(groupID, level)
    {
        _partInfo = info;
    }

    public void GenerateItem()
    {
        var part = new CraftPart(_partInfo.GroupID, _partInfo.Level);
    }
}