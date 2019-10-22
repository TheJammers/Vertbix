using System;
using System.Collections;
using System.Collections.Generic;
using HyperCasual.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerDialog : Dialog
{
    protected Tower tower;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image thumbnailImage;
    [SerializeField] private TextMeshProUGUI descriptionText;

    public override void ShowDialog(EventHandler<ValueArgs<object>> onUpdate, EventHandler<ValueArgs<object>> onClose, object[] args = null)
    {
        tower = args[0] as Tower;
        base.ShowDialog(onUpdate, onClose, args);

        gameObject.SetActive(true);
    }

    protected override void UpdateUI()
    {
        base.UpdateUI();
        nameText.text = tower.Data.Name;
        thumbnailImage.sprite = tower.Data.Thumbnail;
        descriptionText.text = tower.Data.Description;
    }

    public void OnSell()
    {
        tower.Sell();
        base.RaiseOnClose(null);
    }

    public void Close()
    {
        gameObject.SetActive(false);
        base.RaiseOnClose(null);
    }
}
