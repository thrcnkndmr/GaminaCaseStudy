using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;

    public GameObject tapToStartPanel;
    public GameObject levelPassedPanel;
    public GameObject levelFailedPanel;
    public TextMeshProUGUI ballsCountText;
    public TextMeshProUGUI ballsInHoleRatioText;
    public bool TapToStartPlayed;


    public TextMeshProUGUI levelsPassedText;

    private void Awake()
    {
        _gameManager = GameManager.Instance;

    }

    private void Start()
    {
        UpdateUI();
        UpdateLevelsPassed(_gameManager.levelManager.currentLevel);
        if (!TapToStartPlayed)
        {
            ShowTapToStartPanel();
        }
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
        levelPassedPanel.SetActive(true);
    }

    public void ShowLevelFailedPanel()
    {
        levelFailedPanel.SetActive(true);
    }

    public void UpdateUI()
    {
        ballsCountText.text = _gameManager.ballCount.ToString();
        ballsInHoleRatioText.text = _gameManager.ballsInHole + " / " + _gameManager.levelPassCount;
    }
}