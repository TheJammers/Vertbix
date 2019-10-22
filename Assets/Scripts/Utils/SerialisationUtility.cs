using System;
using System.Collections;
using System.Linq;
using Boo.Lang;
using UnityEngine;

public class SerialisationUtility
{
    private static System.Collections.Generic.List<WagonData> wagonData;
    private static System.Collections.Generic.List<WagonData> WagonData 
    {
        get
        {
            if (wagonData == null)
            {
                wagonData = Resources.LoadAll<WagonData>("Data/WagonData").ToList();
            }

            return wagonData;
        }
    }
    
    private static System.Collections.Generic.List<TowerData> towerData;
    private static System.Collections.Generic.List<TowerData> TowerData 
    {
        get
        {
            if (towerData == null)
            {
                towerData = Resources.LoadAll<TowerData>("Data/TowerData").ToList();
            }

            return towerData;
        }
    }
    
    public static Wagon DeserialiseWagon(string wagonDataString)
    {
        var splitWagonData = wagonDataString.Split(new[]{'\\'}, StringSplitOptions.RemoveEmptyEntries);
        if (splitWagonData.Any())
        {
            var wagonId = splitWagonData[0];
            var wagonData = WagonData.FirstOrDefault(x => x.ID == wagonId);
            
            if (wagonData != null)
            {
                return DeserialiseWagon(wagonData, wagonDataString.Substring(wagonId.Length));
            }
        }

        return null;
    }

    public static Wagon DeserialiseWagon(WagonData wagonData, string wagonDataString = "")
    {
        var wagon = GameObject.Instantiate(wagonData.WagonPrefab);

        if (wagon as FiringWagon != null)
        {
            var towers = wagonDataString.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => DeserialiseTower(s)).Where(t => t != null).ToList();
            
            (wagon as FiringWagon).Init(wagonData, towers);
        }
        else
        {
            wagon.Init(wagonData);
        }

        return wagon;
    }

    public static Tower DeserialiseTower(string towerDataString)
    {
        var splitTowerData = towerDataString.Split(new[]{'\\'}, StringSplitOptions.RemoveEmptyEntries);
        if (splitTowerData.Any())
        {
            var towerId = splitTowerData[0];
            var towerData = TowerData.FirstOrDefault(x => x.ID == towerId);
            
            if (towerData != null)
            {
                return DeserialiseTower(towerData, towerDataString.Substring(towerId.Length));
            }
        }

        return null;
    }
    
    public static Tower DeserialiseTower(TowerData towerData, string towerDataString = "")
    {
        var tower = GameObject.Instantiate(towerData.TowerPrefab);

        tower.Init(towerData);

        return tower;
    }
}
