using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSelection : MonoBehaviour {

    public float waitTime = 2f;
    
    private Renderer rend;
    private bool isSelected;

    private void Start() {
        rend = GetComponent<Renderer>();
    }

    private void OnMouseDown() {
        if (!isSelected) {
            isSelected = true;
            rend.material.SetFloat("_OutlineEnabled", 1);
            StartCoroutine(OutlineWait());
        }
        else {
            Debug.Log("Open Info");
        }
    }

    private IEnumerator OutlineWait() {
        yield return new WaitForSecondsRealtime(waitTime);
        rend.material.SetFloat("_OutlineEnabled", 0);
        isSelected = false;
    }
}
