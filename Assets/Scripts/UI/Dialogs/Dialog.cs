using System;
using System.Collections;
using System.Collections.Generic;
using HyperCasual.Data;
using HyperCasual.Extensions;
using UnityEngine;
using UnityEngine.Assertions.Must;

public  class Dialog : MonoBehaviour
{
    protected event EventHandler<ValueArgs<object>> OnUpdate;
    protected event EventHandler<ValueArgs<object>> OnClose;

    public virtual void ShowDialog(EventHandler<ValueArgs<object>> onUpdate, EventHandler<ValueArgs<object>> onClose, object[] args = null)
    {
        OnUpdate += onUpdate;
        OnClose += onClose;
        
        UpdateUI();
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
    
    public virtual void Show()
    {
        UpdateUI();
        gameObject.SetActive(true);
    }

    protected void RaiseOnClose(ValueArgs<object> args)
    {
        this.Raise(OnClose, args);
    }

    protected virtual void UpdateUI()
    {
    }
    
    protected void RaiseUpdate(ValueArgs<object> args)
    {
        this.Raise(OnUpdate, args);
    }
}
