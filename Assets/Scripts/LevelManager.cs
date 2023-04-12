using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int levelNumber = 1;
    public int currentLevel;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    private void Start()
    {
        LoadGame();
    }

    public void NextLevel()
    {
        currentLevel++;
    }

    public void LoadGame()
    {
        {
            currentLevel = PlayerPrefs.GetInt("Level", 1); 
            _gameManager.ballCount = PlayerPrefs.GetInt("BallsCount", 10); 
            _gameManager.levelPassCount = PlayerPrefs.GetInt("BallsNeededToPassLevel", 5);
        }
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}