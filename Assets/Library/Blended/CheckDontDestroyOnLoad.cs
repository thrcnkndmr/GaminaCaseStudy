using UnityEngine;

namespace Blended
{
    public class CheckDontDestroyOnLoad : MonoBehaviour
    {
        private GameObject _obj;

        private void Awake()
        {
            GetInstance();
        }

        private void GetInstance()
        {
            DontDestroyOnLoad(gameObject);
            if (_obj == null) _obj = gameObject;
            else Destroy(gameObject);
        }
    }
}