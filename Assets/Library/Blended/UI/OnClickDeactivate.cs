using UnityEngine;
using UnityEngine.EventSystems;

namespace Blended.UI
{
    public class OnClickDeactivate : MonoBehaviour, IPointerDownHandler
    {
        private bool _isClicked;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_isClicked)
                return;
            _isClicked = true;
            gameObject.SetActive(false);
        }
    }
}