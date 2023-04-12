using Blended;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoSingleton<GameManager>
{
    [Header("MANAGERS")] public UIManager uiManager;
    [SerializeField] private BallsManager ballsManager;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Pool pool;
    private TouchManager _touchManager;

    [Header("Other")]
    [SerializeField] private EnvironmentRandomizer environmentRandomizer;
    [SerializeField] private GameObject currentMaze;
    [SerializeField] private Transform mazeSpawn;
    
    public bool isGameNotStarted = true;
    public int levelPassCount = 5;
    public int ballCount = 10;
    public int ballsInHole;

    private void OnEnable()
    {
        _touchManager = TouchManager.Instance;
        _touchManager.onTouchBegan += OnTouchBegan;
    }

    private void OnDisable()
    {
        _touchManager.onTouchBegan -= OnTouchBegan;
    }

    private void OnTouchBegan(TouchInput touchInput)
    {
        if (isGameNotStarted)
        {
            ballsManager.StartSpawn(ballCount);
        }

        isGameNotStarted = false;
    }
    
    private void Start()
    {
        GetRandomEnvironment();
    }

    public void GetRandomEnvironment()
    {
        var randomMaze = environmentRandomizer.Maze;
        currentMaze = randomMaze[Random.Range(0, randomMaze.Count)];
        Instantiate(currentMaze, mazeSpawn.position, Quaternion.identity,mazeSpawn);
    }


    public void BallInHole()
    {
        ballsInHole++;
        
        if (ballsInHole >= levelPassCount)
        {
            ballCount += 5;
            levelPassCount += 5;
            ballsInHole = 0;
            levelManager.NextLevel();
            PlayerPrefs.SetInt("Level", levelManager.currentLevel);
            PlayerPrefs.SetInt("BallsCount", ballCount);
            PlayerPrefs.SetInt("BallsNeededToPassLevel", levelPassCount);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            levelManager.RestartLevel();
        }
    }
}