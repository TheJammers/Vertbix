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
        
        RecoverSavedVehicleData();

        Debug.LogError(GetComponentsInChildren<MeshFilter>().Select(x => x.mesh.vertexCount).Sum());
        
        SaveVehicleProgress();
    }

    public void AddWagon(Wagon wagon)
    {
        wagon.transform.SetParent(transform);
        wagon.transform.localPosition = Vector3.zero;
        
        if (Wagons.Count > 0)
        {
            SegmentUtility.SnapJoints(wagon.transform, wagon.StartJoint.transform,
                Wagons[Wagons.Count - 1].EndJoint.transform);
        }
        
        Wagons.Add(wagon);
        
        SaveVehicleProgress();
    }

    private void RecoverSavedVehicleData()
    {
        if (PlayerPrefs.HasKey(saveName))
        {
            foreach (var wagonDataString in PlayerPrefs.GetString(saveName).Split(new []{'\n'}, StringSplitOptions.RemoveEmptyEntries))
            {
                var wagon = SerialisationUtility.DeserialiseWagon(wagonDataString);
                if (wagon != null)
                {
                    AddWagon(wagon);
                }
                else
                {
                    Debug.Log("Cant find wagon for: " + wagonDataString);
                }
            }
        }
        else
        {
            var locomotiveData = GameManager.Instance.WagonData.FirstOrDefault(x => x.ID == "Locomotive");
            AddWagon(SerialisationUtility.DeserialiseWagon(locomotiveData));
        }
    }
    
    public void SaveVehicleProgress()
    {
        PlayerPrefs.SetString(saveName, string.Join("\n", Wagons.Select(x => x.ToString()).ToArray()));
    }
}