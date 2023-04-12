using System;
using System.Collections;
using System.Collections.Generic;
using Blended;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoSingleton<GameManager>
{
    [Header("MANAGERS")] public UIManager uiManager;
    public BallsManager ballsManager;
    public EnvironmentRandomizer environmentRandomizer;
    public Pool pool;

    public GameObject currentMaze;
    public Transform mazeSpawn;

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

  

    

}