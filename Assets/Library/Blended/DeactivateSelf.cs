using UnityEngine;

namespace Blended
{
    public class DeactivateSelf : MonoBehaviour
    {
        public float timer = 3;
        float countdown = 1;

        private void Start()
        {
            countdown = timer;
        }

        void Update()
        {
            countdown -= Time.deltaTime;
            if (countdown < 0f)
            {
                gameObject.SetActive(false);
                countdown = timer;
            }
        }

        public void ResetTimer()
        {
            countdown = timer;
        }
    }
}