using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private float upgradeButtonScoreShow = 25;
    [SerializeField] private Button upgradeButton;
    [SerializeField]
    private Text scoreText;

    private void Start()
    {
        GameManager.Instance.ScoreChangedEvent += UpdateScore;
        UpdateScore(GameManager.Instance.Score);
    }

    private void UpdateScore(float score)
    {
        scoreText.text = "Score: " + (int)score;
        if (score >= upgradeButtonScoreShow && !upgradeButton.gameObject.activeSelf)
        {
            upgradeButton.gameObject.SetActive(true);
        }
    }

    public void ShowShop()
    {
        foreach (var wagon in GameManager.Instance.WagonData)
        {
            
        }
    }
}
