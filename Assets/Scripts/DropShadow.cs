using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DropShadow : MonoBehaviour {
    private Vector3 ShadowOffset;
    private Material ShadowMaterial;
    private GameObject shadowGameobject;

    private SpriteRenderer spriteRenderer;
    private GameObject shadowGameObjectHolder;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start() {
        ShadowOffset = DropShadowController.instance.ShadowOffset;
        ShadowMaterial = DropShadowController.instance.ShadowMaterial;
        shadowGameobject = DropShadowController.instance.shadowGameobject;

        shadowGameObjectHolder = Instantiate(shadowGameobject, transform.position, Quaternion.identity, transform);
        shadowGameObjectHolder.transform.position += Vector3.Scale(transform.lossyScale, ShadowOffset);
        shadowGameObjectHolder.transform.rotation = transform.rotation;
        shadowGameObjectHolder.GetComponent<SpriteRenderer>().sprite = spriteRenderer.sprite;
    }
}