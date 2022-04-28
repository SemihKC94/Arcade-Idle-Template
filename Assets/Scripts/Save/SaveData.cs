using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int Level { get; set; }
    public int CharacterLevel { get; set; }
    public float CharacterExp { get; set; }
    public int PlaneCount { get; set; }
    public string GamePlayVersion { get; set; }
    public double SoftCurrency { get; set; }
    public double HardCurrency { get; set; }
    public Territory TerritoriesOwnStatus { get; set; }
}