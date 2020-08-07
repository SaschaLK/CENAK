using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using TouchScript.Gestures.TransformGestures;
using Unity.Mathematics;
using UnityEngine;

public class MainCameraController : MonoBehaviour {

    public static MainCameraController instance;

    public ScreenTransformGesture moveGesture;
    public TapGesture tapGesture;
    public ScreenTransformGesture zoomGesture;
    [Space(10f)]
    public float zoomFactor = 10;
    public Vector2 min;
    public Vector2 max;
    [Space(10f)]
    public int waitTime;
    public GameObject homeButton;

    [HideInInspector] public bool detailedView;

    private Vector2 boundsMax;
    private Vector2 boundsMin;
    private Vector3 moveStartPosition;
    private Vector3 zoomStartPosition;
    private Vector3 direction;

    private bool inputGiven;
    private float elapsedTime;
    private Vector3 cameraStartPosition;
    private float cameraStartSize;
    private float screenRatio;

    private Vector2 currentBoundsMax;
    private Vector2 currentBoundsMin;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        cameraStartPosition = transform.position;
        cameraStartSize = Camera.main.orthographicSize;
        screenRatio = (float)Screen.width / (float)Screen.height;

        boundsMax.x = cameraStartSize * screenRatio + transform.position.x;
        boundsMax.y = cameraStartSize + transform.position.y;
        boundsMin.x = -cameraStartSize * screenRatio + transform.position.x;
        boundsMin.y = -cameraStartSize + transform.position.y;
    }

    private void OnEnable() {
        moveGesture.TransformStarted += moveStartPositionHandler;
        moveGesture.Transformed += moveGestureHandler;
        tapGesture.Tapped += tapGestureHandler;
        zoomGesture.TransformStarted += zoomStartPositionHandler;
        zoomGesture.Transformed += zoomGestureHandler;
    }

    private void OnDisable() {
        moveGesture.TransformStarted -= moveStartPositionHandler;
        moveGesture.Transformed -= moveGestureHandler;
        tapGesture.Tapped -= tapGestureHandler;
        zoomGesture.TransformStarted -= zoomStartPositionHandler;
        zoomGesture.Transformed -= zoomGestureHandler;
    }

    private void moveStartPositionHandler(object sender, System.EventArgs e) {
        if (!detailedView) {
            moveStartPosition = Camera.main.ScreenToWorldPoint(moveGesture.ScreenPosition);
        }
    }

    private void moveGestureHandler(object sender, System.EventArgs e) {
        if (!detailedView) {
            direction = moveStartPosition - Camera.main.ScreenToWorldPoint(moveGesture.ScreenPosition);
            transform.position += direction;
            ClampCamera();
        }
    }

    private void tapGestureHandler(object sender, System.EventArgs e) {
        if (!detailedView) {
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(tapGesture.ScreenPosition).x, Camera.main.ScreenToWorldPoint(tapGesture.ScreenPosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
            if (hit.transform != null) {
                hit.transform.GetComponent<ImageSelection>().OpenPanel();
            }
        }
    }

    private void zoomStartPositionHandler(object sender, System.EventArgs e) {
        if (!detailedView) {
            zoomStartPosition = Camera.main.ScreenToWorldPoint((zoomGesture.ActivePointers[0].Position + zoomGesture.ActivePointers[1].Position) / 2);
        }
    }

    private void zoomGestureHandler(object sender, System.EventArgs e) {
        if (!detailedView) {
            Zoom(zoomGesture.DeltaScale, zoomStartPosition);
        }
    }

    private void Zoom(float increment, Vector3 zoomPosition) {
        TakeAction();
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize *= (2 - increment), 0.1f, 10f);
        Vector3 zoomWorldPositionDelta;
        if(zoomGesture.ActivePointers.Count > 0) {
            zoomWorldPositionDelta = zoomPosition - Camera.main.ScreenToWorldPoint((zoomGesture.ActivePointers[0].Position + zoomGesture.ActivePointers[1].Position) / 2);
        }
        else {
            zoomWorldPositionDelta = zoomPosition - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        transform.position += zoomWorldPositionDelta;
        ClampCamera();
    }

    private void ClampCamera() {
        currentBoundsMax = new Vector2(transform.position.x + (Camera.main.orthographicSize * screenRatio), transform.position.y + Camera.main.orthographicSize);
        currentBoundsMin = new Vector2(transform.position.x + (-Camera.main.orthographicSize * screenRatio), transform.position.y - Camera.main.orthographicSize);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, transform.position.x + (boundsMin.x - currentBoundsMin.x), transform.position.x + (boundsMax.x - currentBoundsMax.x)), Mathf.Clamp(transform.position.y, transform.position.y + (boundsMin.y - currentBoundsMin.y), transform.position.y + (boundsMax.y - currentBoundsMax.y)), -10);
    }

    public void Reload() {
        SelectionManager.instance.ClosePanel();
        Camera.main.transform.position = cameraStartPosition;
        Camera.main.orthographicSize = cameraStartSize;
        inputGiven = false;
        homeButton.SetActive(false);
        elapsedTime = 0f;
    }

    public void TakeAction() {
        if (!inputGiven) {
            homeButton.SetActive(true);
        }
        inputGiven = true;
        elapsedTime = 0;
    }

    private void Update() {
        if (!detailedView) {
            if (Input.GetAxis("Mouse ScrollWheel") != 0) {
                Zoom(Input.GetAxis("Mouse ScrollWheel") + 1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }

        if (inputGiven) {
            elapsedTime += Time.deltaTime;

            if(elapsedTime > waitTime) {
                Reload();
            }
        }
    }
}
