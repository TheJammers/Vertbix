using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WagonShopElement : MonoBehaviour
{
    private WagonData data;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image thumbnailImage;
    [SerializeField] private TextMeshProUGUI weightText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Button buyButton;
    [SerializeField] private TextMeshProUGUI buyButtonText;
    public delegate void BuyClickedDelegate(WagonData wagonData);

    public event BuyClickedDelegate BuyClickedEvent;
    public void Init(WagonData data)
    {
        this.data = data;
        nameText.text = data.Name;
        thumbnailImage.sprite = data.Thumbnail;
        weightText.text = data.Weight.ToString();
        descriptionText.text = data.Description;
        GameManager.Instance.ScoreChangedEvent += UpdateBuyButton;
        UpdateBuyButton();
    }

    private void UpdateBuyButton(float score = -1)
    {
        if (score == -1)
        {
            score = GameManager.Instance.Score;
        }
        if (data.Cost <= score)
        {
            buyButton.enabled = true;
            buyButtonText.text = "Buy: " + data.Cost;
            buyButtonText.color = Color.green;
        }
        else
        {
            buyButton.enabled = false;
            buyButtonText.text = data.Cost.ToString();
            buyButtonText.color = Color.red;
        }
    }

    public void BuyButtonClicked()
    {
        BuyClickedEvent(data);
    }
}
