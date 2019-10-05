using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WagonShop : MonoBehaviour
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
        if (GameManager.Instance.RemoveScore(wagonData.Cost))
        {
            GameManager.Instance.vehicleMovement.GetVehicle().AddWagon(wagonData);
        }

    }
}