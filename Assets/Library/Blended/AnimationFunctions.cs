using UnityEngine;

namespace Blended
{
    public class AnimationFunctions : MonoBehaviour
    {
        public void DestroySelf()
        {
            Destroy(gameObject);
        }
        public void DestroyParent()
        {
            Destroy(transform.parent.  gameObject);
        }

        public void DeactivateParent()
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}