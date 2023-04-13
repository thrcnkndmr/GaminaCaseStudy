using Blended;
using MoreMountains.NiceVibrations;
using UnityEngine;

public class BallInteractions : MonoBehaviour
{
    private GameManager _gameManager;
    public ParticleSystem ballParticle;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            transform.SetParent(Pool.Instance.poolObjects[0].transform);
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
            ballParticle.Play();
            ballParticle.GetComponent<AudioSource>().Play();
            _gameManager.BallInHole();
            MMVibrationManager.Haptic(HapticTypes.MediumImpact);
            
        }
    }

 
}