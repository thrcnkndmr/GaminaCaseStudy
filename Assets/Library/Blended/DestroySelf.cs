using System.Collections;
using UnityEngine;

namespace Blended
{
    public delegate void CreateBeforeDestroy(GameObject create, Transform createdTransform);

    public class DestroySelf : MonoBehaviour
    {
        public float countdown = 1;
        private float _timer;
        public GameObject spawnBeforeDestroy;
        [HideInInspector] public CreateBeforeDestroy cbd;

        private bool _isCreated = false;

        private void Start()
        {
            _timer = countdown;
        }

        void LateUpdate()
        {
            _timer -= Time.deltaTime;

            if (!(_timer < 0f)) return;
            if (cbd != null && spawnBeforeDestroy != null && !_isCreated)
            {
                cbd.Invoke(spawnBeforeDestroy, transform);
                _isCreated = true;
            }

            StartCoroutine(WaitAFrame());
        }

        public void ResetTimer()
        {
            _timer = countdown;
        }

        private IEnumerator WaitAFrame()
        {
            yield return new WaitForEndOfFrame();
            Destroy(gameObject);
        }
    }
}