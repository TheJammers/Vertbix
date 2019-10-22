using System;
using HyperCasual.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : Dialog
{
    [SerializeField] private float upgradeButtonScoreShow = 25;
    [SerializeField] private Button shopButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private WagonShop shopDialog;

    private bool isUpgradeAvailable;

    private void Start()
    {
        GameManager.Instance.ScoreChangedEvent += UpdateScore;
        UpdateScore(GameManager.Instance.Score);
        isUpgradeAvailable = GameManager.Instance.TotalScore > upgradeButtonScoreShow;
        shopButton.gameObject.SetActive(true);
    }
    
    private void UpdateScore(float score)
    {
        scoreText.text = "Score: " + (int) score;

        if (!isUpgradeAvailable && GameManager.Instance.TotalScore > upgradeButtonScoreShow)
        {
            shopButton.gameObject.SetActive(true);

            isUpgradeAvailable = true;
        }
    }

    public void ShowShop()
    {
        GameManager.Instance.uiController. PushDialog(shopDialog, new[] {GameManager.Instance.WagonData}, OnWagonBought, null);
    }

    private void OnWagonBought(object sender, ValueArgs<object> args)
    {
        var wagonData = args.Value as WagonData;
        
        if (GameManager.Instance.RemoveScore(wagonData.Cost))
            
        {
            GameManager.Instance.vehicleMovement.GetVehicle().AddWagon(SerialisationUtility.DeserialiseWagon(wagonData));
        }
    }

    public override void ShowDialog(EventHandler<ValueArgs<object>> onUpdate, EventHandler<ValueArgs<object>> onClose, object[] args = null)
    {
        gameObject.SetActive(true);
        base.ShowDialog(onUpdate, onClose, args);
    }
}