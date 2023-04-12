using UnityEngine;

public class ConstrainToCollider : MonoBehaviour
{
    public Collider Collider;


    private void LateUpdate()
    {
        if (Collider != null)
        {
            transform.position = Collider.ClosestPoint(transform.position);
        }
    }
}