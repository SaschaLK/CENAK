using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using TouchScript.Gestures.TransformGestures;
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

    [HideInInspector] public bool detailedView;

    private Vector3 moveStartPosition;
    private Vector3 direction;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        //Screen.SetResolution(Screen.width, Screen.height, true);
        //Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        //PlayerPrefs.DeleteAll();
    }

    private void OnEnable() {
        moveGesture.TransformStarted += moveStartPositionHandler;
        moveGesture.Transformed += moveGestureHandler;
        tapGesture.Tapped += tapGestureHandler;
        zoomGesture.Transformed += zoomGestureHandler;
    }

    private void OnDisable() {
        moveGesture.TransformStarted -= moveStartPositionHandler;
        moveGesture.Transformed -= moveGestureHandler;
        tapGesture.Tapped -= tapGestureHandler;
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
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, min.x, max.x), Mathf.Clamp(transform.position.y, min.y, max.y), -10);
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

    private void zoomGestureHandler(object sender, System.EventArgs e) {
        if (!detailedView) {
            Zoom(zoomGesture.DeltaScale);
        }
    }

    private void Zoom(float increment) {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize *= (2 - increment), 0.1f, 10f);
    }

    private void Update() {
        if (!detailedView) {
            if (Input.GetAxis("Mouse ScrollWheel") != 0) {
                Zoom(Input.GetAxis("Mouse ScrollWheel") + 1);
            }
        }
    }
}
