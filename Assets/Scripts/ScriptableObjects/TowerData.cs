using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CreateTowerData", order = 2)]
public class TowerData : ScriptableObject
{
    public string Name;
    public Tower TowerPrefab; 
    public Dialog TowerDialog;
    public Sprite Thumbnail;
    public float Cost;
    public string Description;
    public string ID;
}
