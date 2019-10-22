using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HyperCasual.Data;
using HyperCasual.Extensions;
using UnityEngine;

public class WagonShop : Dialog
{
    [SerializeField] private WagonData locomotivData;
    [SerializeField] private WagonShopElement shopElementPrefab;
    [SerializeField] private Transform contentContainer;
    private List<WagonShopElement> shopElements;
    private void Awake()
    {
        foreach (Transform child in contentContainer) {
            Destroy(child.gameObject);
        }
        shopElements = new List<WagonShopElement>();
    }

    public override void ShowDialog(EventHandler<ValueArgs<object>> onUpdate, EventHandler<ValueArgs<object>> onClose, object[] args = null)
    {
        base.ShowDialog(onUpdate ,onClose, args);
        
        var wagonData = args[0] as List<WagonData>;

        gameObject.SetActive(true);
        
        Populate(wagonData);
    }

    public void Populate(List<WagonData> data)
    {
        var dataToDisplay = data.Where(x => x != locomotivData).ToList();
        if (contentContainer.childCount == 0)
        {
            for (int i = 0; i < dataToDisplay.Count; i++)
            {
                var shopElement = Instantiate(shopElementPrefab, contentContainer);
                shopElement.BuyClickedEvent += BuyWagon;
                shopElements.Add(shopElement);
            }
        }

        for (int i = 0; i < dataToDisplay.Count; i++)
        {
            var shopElement = shopElements[i];
            var dataForElement = dataToDisplay[i];
            shopElement.Init(dataForElement);
        }
    }

    void BuyWagon(WagonData wagonData)
    {
        base.RaiseUpdate(new ValueArgs<object>(wagonData));
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
        base.RaiseOnClose(null);
    }
}