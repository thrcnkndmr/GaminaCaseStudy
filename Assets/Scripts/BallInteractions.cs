using System.Collections;
using System.Collections.Generic;
using Blended;
using UnityEngine;

public class BallInteractions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            GetComponent<ConstrainToCollider>().enabled = true;
            GetComponent<BallInteractions>().transform.SetParent(Pool.Instance.poolObjects[0].transform);
        }
    }
}
