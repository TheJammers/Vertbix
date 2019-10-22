using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerShopElement : MonoBehaviour
{
    private TowerData data;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image thumbnailImage;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Button buyButton;
    [SerializeField] private TextMeshProUGUI buyButtonText;
    public delegate void BuyClickedDelegate(TowerData wagonData);

    public event BuyClickedDelegate BuyClickedEvent;
    public void Init(TowerData data)
    {
        this.data = data;
        nameText.text = data.Name;
        thumbnailImage.sprite = data.Thumbnail;
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

    private void OnDestroy()
    {
        GameManager.Instance.ScoreChangedEvent -= UpdateBuyButton;
    }
}
