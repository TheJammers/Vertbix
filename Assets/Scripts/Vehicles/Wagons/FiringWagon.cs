using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HyperCasual.Data;
using HyperCasual.Extensions;
using TopDownRace;
using UnityEngine;

public class FiringWagon : Wagon
{
    [SerializeField] private Transform[] towerPositions;
    [SerializeField] public List<Tower> Towers;

    public virtual void Init(WagonData data, List<Tower> towers)
    {
        base.Init(data);

        foreach (var tower in towers)
        {
            AddTower(tower);
        }
    }

    private void AddTower(Tower towerToAdd)
    {
        if (towerPositions.Length > Towers.Count)//have space
        {
            var towerPosition = towerPositions[Towers.Count];

            towerToAdd.SetParent(transform);
            towerToAdd.transform.position = towerPosition.position;

            towerToAdd.OnSell += OnSellTower;
            
            Towers.Add(towerToAdd);
            
            Debug.LogError("Fix this");
            if (GameManager.Instance.vehicleMovement.vehicleObject != null)
            {
                GameManager.Instance.vehicleMovement.vehicleObject.SaveVehicleProgress();
            }
        }
        else
        {
            Debug.LogError("No space for tower");
        }
    }

    private void OnSellTower(object sender, ValueArgs<Tower> args)
    {
        Towers.Remove(args.Value);
        
        Debug.LogError("Fix this");
        if (GameManager.Instance.vehicleMovement.vehicleObject != null)
        {
            GameManager.Instance.vehicleMovement.vehicleObject.SaveVehicleProgress();
        }
    }
    
    protected override void OnUpdate(object sender, ValueArgs<object> eventArgs)
    {
        if (eventArgs != null && eventArgs.Value as Tower != null)
        {
            AddTower(eventArgs.Value as Tower);
        }
        else
        {
            Debug.Log(eventArgs.Value);
        }
    }

    public override string ToString()
    {
        return base.ToString() + "\\" + string.Join("/", Towers.Select(x => x.ToString()));
    }
    
//    public class TowerDealogUpdateArgs
//        : EventArgs
//    {
//        public bool bought;
//        public TowerData towerData
//    }
}
