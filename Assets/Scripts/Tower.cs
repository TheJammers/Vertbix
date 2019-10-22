using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HyperCasual;
using HyperCasual.Data;
using HyperCasual.Extensions;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public event EventHandler<ValueArgs<Tower>> OnSell;
    public TowerData Data;

    private CollisionReporter[] reporters;

    private void Awake()
    {
        reporters = gameObject.GetComponentsInChildren<CollisionReporter>();
        foreach (var reporter in reporters)
        {
            reporter.SubscribeToOnMouseDown(MouseDown);
        }
    }

    public virtual void Init(TowerData data)
    {
        Data = data;
    }

    private void OnDestroy()
    {
        foreach (var reporter in reporters.Where(x => x != null))
        {
            reporter.UnsubscribeToOnMouseDown(MouseDown);
        }
    }

    private void MouseDown(object sender, EventArgs e)
    {
        GameManager.Instance.uiController.PushDialog(Data.TowerDialog, new []{ this }, null, null);
    }

    public void Sell()
    {
        this.Raise(OnSell, new ValueArgs<Tower>(this));
        Destroy(gameObject);
    }

    public override string ToString()
    {
        return Data.ID;
    }
}
