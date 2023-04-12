using System;
using Blended;
using Unity.VisualScripting;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
    private Pool pool;
    private TouchManager _touchManager;
    
    public Transform ballsParent;
    public Transform ballsSpawnPoint;
    
    public int ballCount = 10;
    public Transform ballParent;
    public int levelPassCount = 5;
  
    private bool isGameNotStarted = true;


    private void Awake()
    {
        pool = Pool.Instance;
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
            StartSpawn(30);
        }
    }


    private void StartSpawn(int SpawnAmount)
    {
        for (int i = 0; i < SpawnAmount; i++)
        { 
            pool.SpawnObject(ballsSpawnPoint.position, "Ball", ballsParent);
        }
        
        isGameNotStarted = false;
    }
}

