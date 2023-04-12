using Blended;
using UnityEngine;

public class RotateMaze : MonoBehaviour
{
    public float sensitivity = 1f;
    private TouchManager _touchManager;

    private void OnEnable()
    {
        _touchManager = TouchManager.Instance;
        _touchManager.onTouchMoved += OnTouchMoved;
    }

    private void OnDisable()
    {
        _touchManager.onTouchMoved -= OnTouchMoved;
    }

    private void OnTouchMoved(TouchInput touch)
    {
        float mouseX = Input.GetAxis("Mouse X");
        float rotationAmount = mouseX * sensitivity;
        transform.Rotate(Vector3.back, rotationAmount);
    }
}