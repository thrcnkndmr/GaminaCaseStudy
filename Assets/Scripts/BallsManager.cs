using System;
using Blended;
using Unity.VisualScripting;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
    public Transform ballsParent;
    public Transform ballsSpawnPoint;
    private Pool pool;
    private TouchManager _touchManager;
    private bool isGameStarted = true;


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
        if (isGameStarted)
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
        
        isGameStarted = false;
    }
}

