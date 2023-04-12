using System;
using UnityEngine;

public class ConstrainToCollider : MonoBehaviour
{
    public Collider Collider;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            GetComponent<ConstrainToCollider>().enabled = true;
        }
    }

    private void LateUpdate()
    {
        if (Collider != null)
        {
            transform.position = Collider.ClosestPoint(transform.position);
        }
    }
}