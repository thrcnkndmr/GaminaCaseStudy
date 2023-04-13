using Blended;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
    private Pool pool;
    private TouchManager _touchManager;
    private GameManager _gameManager;

    [SerializeField] private Transform ballsParent;
    [SerializeField] private Transform ballsSpawnPoint;




    private void Awake()
    {
        pool = Pool.Instance;
    }

    public void StartSpawn(int SpawnAmount)
    {
        for (int i = 0; i < SpawnAmount; i++)
        {
            pool.SpawnObject(ballsSpawnPoint.position, "Ball", ballsParent);
        }
        
    }

   
}

