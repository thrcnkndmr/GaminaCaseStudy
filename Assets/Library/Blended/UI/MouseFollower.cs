using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    private Canvas myCanvas;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.TryGetComponent<Canvas>(out var canvas)) myCanvas = canvas;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
        transform.position = myCanvas.transform.TransformPoint(pos);
        
        if (Input.GetMouseButtonDown(0))
            transform.GetChild(0).gameObject.SetActive(true);
        else if (Input.GetMouseButtonUp(0))
            transform.GetChild(0).gameObject.SetActive(false);
    }
}
