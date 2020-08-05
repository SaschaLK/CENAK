using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShadowController : MonoBehaviour {
    public static DropShadowController instance;

    public Vector3 ShadowOffset;
    public Material ShadowMaterial;
    public GameObject shadowGameobject;

    private void Awake() {
        instance = this;
    }
}
