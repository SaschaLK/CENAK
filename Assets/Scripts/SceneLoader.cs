using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SceneLoader : MonoBehaviour {

    public int waitTime;
    public GameObject homeButton;

    private bool inputGiven;
    private float elapsedTime;
    private Vector3 cameraStartPosition;
    private float cameraStartSize;

    private void Start() {
        cameraStartPosition = Camera.main.transform.position;
        cameraStartSize = Camera.main.orthographicSize;
    }

    private void Update() {
        if((Input.anyKey || Input.touchCount > 0 || Input.GetAxis("Mouse ScrollWheel") != 0) && !inputGiven) {
            inputGiven = true;
            homeButton.SetActive(true);
        }

        if (inputGiven) {
            elapsedTime += Time.deltaTime;
            if (Input.anyKey || Input.touchCount > 0 || Input.GetAxis("Mouse ScrollWheel") != 0) {
                elapsedTime = 0;
            }

            if (elapsedTime > waitTime) {
                Reload();
            }
        }
    }

    public void Reload() {
        SelectionManager.instance.ClosePanel();
        Camera.main.transform.position = cameraStartPosition;
        Camera.main.orthographicSize = cameraStartSize;
        inputGiven = false;
        homeButton.SetActive(false);
        elapsedTime = 0f;
    }
}
