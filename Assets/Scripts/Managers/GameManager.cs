using Blended;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoSingleton<GameManager>
{
    [Header("MANAGERS")] public UIManager uiManager;
    [SerializeField] private BallsManager ballsManager;
    [SerializeField] private Pool pool;
    [SerializeField] private AdManager adManager;
    private TouchManager _touchManager;
    public LevelManager levelManager;
    

    [Header("Other")]
    [SerializeField] private EnvironmentRandomizer environmentRandomizer;
    [SerializeField] private GameObject currentMaze;
    [SerializeField] private Transform mazeSpawn;
    
    public bool isGameNotStarted = true;
    public int levelPassCount;
    public int ballCount;
    private int droppingBallsAmount;
    public int ballsInHole;

    private void Awake()
    {
        UpdateLevelRequirements();
    }

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
            uiManager.HideTapToStart();
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

    public void UpdateLevelRequirements()
    {
        int levelIndex = PlayerPrefs.GetInt("Level", 1);
        ballCount = 5+(5 * levelIndex);
        levelPassCount = 5 + (5 * (levelIndex - 1));
    }
    public void DroppingBallsCounter()
    {
        droppingBallsAmount++;
        Debug.Log(droppingBallsAmount);
    }

    public void BallInHole()
    {
        ballsInHole++;
        uiManager.UpdateUI();

        if (droppingBallsAmount == ballCount)
        {
            if (ballsInHole >= levelPassCount)
            {
                adManager.ShowAd();
                uiManager.ShowLevelPassedPanel();
            }
            else
            {
                adManager.ShowAd();
                uiManager.ShowLevelFailedPanel();
            }
        }
        
    }
}