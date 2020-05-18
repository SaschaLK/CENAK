using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour {

    public static SelectionManager instance;

    public float selectionWaitTime = 2f;

    [SerializeField] private GameObject panel;
    public Text _animalName;
    public Image _animalImage;
    public Text _animalDescription;
    public Button more;
    public string _animalGroup;

    private void Awake() {
        instance = this;
    }
    public void SetAnimal(string animalName, Sprite animalImage, string animalDescription, string animalGroup) {
        _animalName.text = animalName;
        _animalImage.sprite = animalImage;
        _animalDescription.text = animalDescription;
        _animalGroup = animalGroup;

        TouchControlls.instance.detailedView = true;
        panel.SetActive(true);
    }

    public void LoadAnimalGroupScene() {
        SceneManager.LoadScene(_animalGroup);
    }

    public void ClosePanel() {
        panel.SetActive(false);
        StartCoroutine(CloseP());
    }

    private IEnumerator CloseP() {
        yield return new WaitForSecondsRealtime(0.1f);
        TouchControlls.instance.detailedView = false;
    }

}
