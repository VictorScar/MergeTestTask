using System;
using System.Collections;
using System.Collections.Generic;
using MergeGame.Gameplay._Craft;
using UnityEngine;

[Serializable]
public struct FieldData
{
    [SerializeField] private LevelTask[] tasks;
    [SerializeField] private int[] generatorsIDs;
    [SerializeField] private StartItemsInfo[] startItemsInfos;
    
   public int[] GeneratorsIDs => generatorsIDs;
    public StartItemsInfo[] StartItemsInfos => startItemsInfos;
}

[Serializable]
public struct StartItemsInfo
{
    public ItemGroupID GroupID;
    public int Level;
    public int ItemCount;
}