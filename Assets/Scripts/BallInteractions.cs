using System;
using Blended;
using UnityEngine;

public class BallInteractions : MonoBehaviour
{
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            GetComponent<ConstrainToCollider>().enabled = true;
            GetComponent<BallInteractions>().transform.SetParent(Pool.Instance.poolObjects[0].transform);
        }
        else if (other.gameObject.CompareTag("DroppingCollider"))
        {
            _gameManager.DroppingBallsCounter();
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hole"))
        {
            Destroy(gameObject);
            _gameManager.BallInHole();
        }
    }
}