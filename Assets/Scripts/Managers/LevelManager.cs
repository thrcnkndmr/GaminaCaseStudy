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
        LoadGame();
    }
    
    public void LoadGame()
    {
        {
            currentLevel = PlayerPrefs.GetInt("Level", 1);
        }
    }


    public void NextLevel()
    {
        currentLevel++;
        PlayerPrefs.SetInt("Level", currentLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}