using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControlls : MonoBehaviour {

    public static TouchControlls instance;

    public float zoomOutMin = 1;
    public float zoomOutMax = 10;
    public bool detailedView;
    public float margin = 0.1f;
    public float minX, minY, maxX, maxY;

    private Vector3 touchStart;
    private Vector3 touchStartDrag;
    private Vector3 touchEndDrag;
    private bool isDragging;

    private void Awake() {
        instance = this;
    }

    private void Update() {
        if (!detailedView) {
            if (Input.GetMouseButtonDown(0)) {
                touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                touchStartDrag = Input.mousePosition;
                isDragging = true;
            }

            if (Input.GetMouseButtonUp(0)) {
                touchEndDrag = Input.mousePosition;
                float delta = (touchStartDrag - touchEndDrag).magnitude;
                if(delta <= margin) {
                    Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                    RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
                    if(hit.transform != null) {
                        hit.transform.GetComponent<ImageSelection>().OpenPanel();
                    }
                }
            }

            if (Input.touchCount == 2) {
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
                Camera.main.transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), -10);
            }
        }
    }

    private void Zoom(float increment) {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }

}
