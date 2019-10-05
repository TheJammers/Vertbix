using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CreateWagonData", order = 1)]
public class WagonData : ScriptableObject
{
    public string Name;
    public Wagon WagonPrefab;
    public Sprite Thumbnail;
    public float Weight;
    public float Cost;
    public string Description;
}
