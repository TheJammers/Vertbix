using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private float upgradeButtonScoreShow = 25;
    [SerializeField] private Button shopButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private WagonShop shop;

    private void Start()
    {
        GameManager.Instance.ScoreChangedEvent += UpdateScore;
        UpdateScore(GameManager.Instance.Score);
    }

    private void UpdateScore(float score)
    {
        scoreText.text = "Score: " + (int)score;
        if (score >= upgradeButtonScoreShow && !shopButton.gameObject.activeSelf)
        {
            shopButton.gameObject.SetActive(true);
        }
    }

    public void ShowShop()
    {
        shopButton.gameObject.SetActive(false);
        shop.gameObject.SetActive(true);
        shop.Populate(GameManager.Instance.WagonData);
    }

    public void CloseShop()
    {
        shop.gameObject.SetActive(false);
        shopButton.gameObject.SetActive(true);
    }
}
