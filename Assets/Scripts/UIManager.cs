using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;

    public GameObject tapToStartPanel;
    public GameObject levelPassedPanel;
    public GameObject levelFailedPanel;
    public TextMeshProUGUI ballsCollectedText;
    public TextMeshProUGUI ballsInHoleRatioText;
    public bool TapToStartPlayed;


    public TextMeshProUGUI levelsPassedText;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    private void Start()
    {
        UpdateBallsCollected(PlayerPrefs.GetInt("BallsCount"));
        UpdateLevelsPassed(PlayerPrefs.GetInt("Level") + 1);
        UpdateUI();
        if (!TapToStartPlayed)
        {
            ShowTapToStartPanel();
        }
    }

    public void UpdateBallsCollected(int ballsCount)
    {
        ballsCollectedText.text = "Balls Amount: " + ballsCount.ToString();
    }

    public void UpdateLevelsPassed(int levelsPassed)
    {
        levelsPassedText.text = "Level " + levelsPassed.ToString();
    }

    public void ShowTapToStartPanel()
    {
        tapToStartPanel.SetActive(true);
    }

    public void HideTapToStart()
    {
        tapToStartPanel.SetActive(false);
        TapToStartPlayed = true;
    }

    public void ShowLevelPassedPanel()
    {
        tapToStartPanel.SetActive(false);
        levelPassedPanel.SetActive(true);
        levelFailedPanel.SetActive(false);
    }

    public void ShowLevelFailedPanel()
    {
        tapToStartPanel.SetActive(false);
        levelPassedPanel.SetActive(false);
        levelFailedPanel.SetActive(true);
    }

    public void UpdateUI()
    {
        ballsInHoleRatioText.text = _gameManager.ballsInHole + " / " + _gameManager.levelPassCount;
    }
}