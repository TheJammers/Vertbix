using System;
using System.Collections;
using System.Collections.Generic;
using HyperCasual.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WagonDialog : Dialog
{
    protected Wagon wagon;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image thumbnailImage;
    [SerializeField] private TextMeshProUGUI weightText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    public override void ShowDialog(EventHandler<ValueArgs<object>> onUpdate, EventHandler<ValueArgs<object>> onClose, object[] args = null)
    {
        wagon = args[0] as Wagon;
        base.ShowDialog(onUpdate, onClose, args);

        gameObject.SetActive(true);
    }

    protected override void UpdateUI()
    {
        base.UpdateUI();
        nameText.text = wagon.Data.Name;
        thumbnailImage.sprite = wagon.Data.Thumbnail;
        weightText.text = wagon.Data.Weight.ToString();
        descriptionText.text = wagon.Data.Description;
    }

    public void Close()
    {
        gameObject.SetActive(false);
        base.RaiseOnClose(null);
    }
}