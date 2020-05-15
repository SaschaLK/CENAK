using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControlls : MonoBehaviour {

    public float zoomOutMin = 1;
    public float zoomOutMax = 10;

    private Vector3 touchStart;
    private bool isDragging;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }

        if(Input.touchCount == 2) {
            isDragging = false;
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference * 0.01f);
        }
        else if (Input.touchCount == 1 && isDragging) {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
        }
    }

    private void Zoom(float increment) {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }

}
