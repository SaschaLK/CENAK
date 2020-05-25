using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour {

    public static SelectionManager instance;

    [SerializeField] private GameObject panelSmall;
    [SerializeField] private GameObject panelBig;
    public Text _animalNameBig;
    public Text _animalNameSmall;
    public Image _animalImageBig;
    public Image _animalImageSmall;
    public Text _animalDescriptionShort;
    public Text _animalDescriptionFull;
    public string _animalGroup;

    public Button more;

    private void Awake() {
        instance = this;
    }
    public void SetAnimal(string animalName, Sprite animalImage, string animalDescriptionShort, string animalDescriptionFull, string animalGroup) {
        _animalNameBig.text = animalName;
        _animalNameSmall.text = animalName;
        _animalImageBig.sprite = animalImage;
        _animalImageSmall.sprite = animalImage;
        _animalDescriptionShort.text = animalDescriptionShort;
        _animalDescriptionFull.text = animalDescriptionFull;
        _animalGroup = animalGroup;

        TouchControlls.instance.detailedView = true;
        panelSmall.SetActive(true);
    }

    public void OpenBigInfo() {
        panelSmall.SetActive(false);
        panelBig.SetActive(true);
    }

    public void LoadAnimalGroupScene() {
        SceneManager.LoadScene(_animalGroup);
    }

    public void ClosePanel() {
        panelSmall.SetActive(false);
        panelBig.SetActive(false);
        StartCoroutine(CloseP());
    }

    private IEnumerator CloseP() {
        yield return new WaitForSecondsRealtime(0.1f);
        TouchControlls.instance.detailedView = false;
    }

}
