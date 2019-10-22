using System;
using System.Collections.Generic;
using HyperCasual.Data;
using UnityEngine;
using UnityEngine.UI;

public class FiringWagonDialog : WagonDialog
{
    private List<Tower> towers;
    //cheat 
    private bool raise;

    private ValueArgs<object> data;

    [SerializeField] private List<Image> towerButtons;

    [SerializeField] private Sprite plusSprite;
    //
    public override void ShowDialog(EventHandler<ValueArgs<object>> onUpdate, EventHandler<ValueArgs<object>> onClose, object[] args = null)
    {
        base.ShowDialog(onUpdate, onClose, args);
        
        gameObject.SetActive(true);

        towers = (wagon as FiringWagon).Towers;
        
        UpdateUI();
    }

    protected override void UpdateUI()
    {
        base.UpdateUI();

        for (int i = 0; i < towerButtons.Count; i++)
        {
            if (towers != null && i < towers.Count)
            {
                towerButtons[i].sprite = towers[i].Data.Thumbnail;
            }
            else
            {
                towerButtons[i].sprite = plusSprite;
            }
        }
    }

    private void Update()
    {
        if (raise)
        {
            RaiseUpdate(data);
            raise = false;
            
            UpdateUI();
        }
    }

    public void OnTowerSpaceClicked(int index)
    {
        if (towers.Count > index)//existingTower
        {
            var tower = towers[index];
            GameManager.Instance.uiController.PushDialog(tower.Data.TowerDialog, new object[]{tower}, null , UpdateAfterSell);    
        }
        else
        {
            GameManager.Instance.uiController.PushDialog(GameManager.Instance.uiController.TowerShop, new object[] {GameManager.Instance.TowerData}, null, OnBuyTowerClosed);
        }
    }

    private void UpdateAfterSell(object sender, ValueArgs<object> e)
    {
        Debug.Log("Updating Ui");
        UpdateUI();
    }

    private void OnBuyTowerClosed(object sender, ValueArgs<object> args)
    {
        if (args != null && args.Value as Tower != null)
        {
            data = args;
            raise = true;
//            RaiseUpdate(args);
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
        base.RaiseOnClose(null);
    }
}
