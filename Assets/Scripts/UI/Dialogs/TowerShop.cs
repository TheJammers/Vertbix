using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HyperCasual.Data;
using UnityEngine;

public class TowerShop : Dialog
{
    [SerializeField] private TowerShopElement shopElementPrefab;
    [SerializeField] private Transform contentContainer;
    private List<TowerShopElement> shopElements;
    private void Awake()
    {
        foreach (Transform child in contentContainer) {
            Destroy(child.gameObject);
        }
        shopElements = new List<TowerShopElement>();
    }

    public override void ShowDialog(EventHandler<ValueArgs<object>> onUpdate, EventHandler<ValueArgs<object>> onClose, object[] args = null)
    {
        base.ShowDialog(onUpdate ,onClose, args);
        
        var wagonData = args[0] as List<TowerData>;

        gameObject.SetActive(true);
        
        Populate(wagonData);
    }

    public void Populate(List<TowerData> data)
    {
        if (contentContainer.childCount == 0)
        {
            for (int i = 0; i < data.Count; i++)
            {
                var shopElement = Instantiate(shopElementPrefab, contentContainer);
                shopElement.BuyClickedEvent += BuyTower;
                shopElements.Add(shopElement);
            }
        }

        for (int i = 0; i < data.Count; i++)
        {
            var shopElement = shopElements[i];
            var dataForElement = data[i];
            shopElement.Init(dataForElement);
        }
    }

    void BuyTower(TowerData tower)
    {
        gameObject.SetActive(false);
        base.RaiseOnClose(new ValueArgs<object>(SerialisationUtility.DeserialiseTower(tower)));
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
        base.RaiseOnClose(null);
    }
}
