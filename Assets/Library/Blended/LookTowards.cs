using UnityEngine;

namespace Blended
{
    public class LookTowards : MonoBehaviour
    {
        public Transform lookObject;

        private void Update()
        {
            transform.rotation = Quaternion.LookRotation(lookObject.position - transform.position);
        }
    }
}
