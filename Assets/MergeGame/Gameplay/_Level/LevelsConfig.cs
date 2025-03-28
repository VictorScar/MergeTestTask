using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName ="Configs/Levels)", fileName = "LevelsConfig")]
public class LevelsConfig : ScriptableObject
{
    [SerializeField] private FieldData[] datas;

    public FieldData[] Datas => datas;
}
