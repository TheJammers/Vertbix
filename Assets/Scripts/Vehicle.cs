using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TopDownRace;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Vehicle : MonoBehaviour
{
    private const string saveName = "WagonSave";

    public Vector3 frontPoint
    {
        get { return Wagons[0].StartJoint.transform.position; }
    }

    public Vector3 backPoint
    {
        get { return Wagons[Wagons.Count - 1].EndJoint.transform.position; }
    }

    private List<Wagon> Wagons;

    private void Awake()
    {
        Wagons = new List<Wagon>();
        
        if (PlayerPrefs.HasKey(saveName))
        {
            foreach (var wagonName in PlayerPrefs.GetString(saveName).Split(','))
            {
                var wagonData = GameManager.Instance.WagonData.FirstOrDefault(x => x.Name == wagonName);
                if (wagonData != null)
                {
                    AddWagon(wagonData);
                }
                else
                {
                    Debug.Log("Cant find wagon for: " + wagonName);
                }
            }
        }
        else
        {
            AddWagon(GameManager.Instance.WagonData.FirstOrDefault(x => x.Name == "Locomotive"));
        }
    }

    public void AddWagon(WagonData data)
    {
        Wagon newWagon = Instantiate(data.WagonPrefab, transform.position,
            Quaternion.identity, transform);
        
        if (Wagons.Count > 0)
        {
            SegmentUtility.SnapJoints(newWagon.transform, newWagon.StartJoint.transform,
                Wagons[Wagons.Count - 1].EndJoint.transform);
        }

        newWagon.Data = data;
        Wagons.Add(newWagon);
        PlayerPrefs.SetString(saveName, string.Join(",", Wagons.Select(x => x.Data.Name).ToArray()));
    }
}