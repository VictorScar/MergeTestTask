using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct LevelData
{
    [SerializeField] private int widthGameField;
    [SerializeField] private int heightGameField;
    [SerializeField] private LevelTask[] tasks;

    public int WidthGameField => widthGameField;
    public int HeightGameField => heightGameField;
}