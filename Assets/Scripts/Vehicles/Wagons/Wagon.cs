using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HyperCasual;
using HyperCasual.Data;
using UnityEngine;

public class Wagon : MonoBehaviour
{
    [SerializeField] public GameObject StartJoint;

    [SerializeField] public GameObject EndJoint;

    public WagonData Data;

    private CollisionReporter[] reporters;

    private void Awake()
    {
        reporters = gameObject.GetComponentsInChildren<CollisionReporter>();
        foreach (var reporter in reporters)
        {
            reporter.SubscribeToOnMouseDown(MouseDown);
        }
    }

    public virtual void Init(WagonData data)
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
        GameManager.Instance.uiController.PushDialog(Data.WagonDialog, new []{this}, OnUpdate, null);
    }

    protected virtual void OnUpdate(object sender, ValueArgs<object> e)
    {
        Debug.Log(e.Value);
    }

    public override string ToString()
    {
        return Data.ID;
    }
}
