using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour {

    public static SelectionManager instance;

    public bool german;
    public Button germanButton;
    public Button englishButton;

    [SerializeField] private GameObject panelSmall;
    public Button backSmallPanel;
    public Button more;
    [SerializeField] private GameObject panelBig;
    public Button backBigPanel;
    public Button group;

    public Text _animalNameBig;
    public Text _animalNameSmall;
    public Image _animalImageBig;
    public Image _animalImageSmall;
    public Text _animalDescriptionShort;
    public Text _animalDescriptionFull;
    [HideInInspector] public string _animalDescriptionShortDE;
    [HideInInspector] public string _animalDescriptionShortEN;
    [HideInInspector] public string _animalDescriptionFullDE;
    [HideInInspector] public string _animalDescriptionFullEN;
    [HideInInspector] public string _animalGroup;

    private void Awake() {
        instance = this;
    }
    public void SetAnimal(string animalName, Sprite animalImage, string animalDescriptionShortDE, string animalDescriptionShortEN, string animalDescriptionFullDE, string animalDescriptionFullEN, string animalGroup) {
        _animalNameBig.text = animalName;
        _animalNameSmall.text = animalName;
        _animalImageBig.sprite = animalImage;
        _animalImageSmall.sprite = animalImage;
        _animalDescriptionShortDE = animalDescriptionShortDE;
        _animalDescriptionShortEN = animalDescriptionShortEN;
        _animalDescriptionFullDE = animalDescriptionFullDE;
        _animalDescriptionFullEN = animalDescriptionFullEN;

        if (german) {
            _animalDescriptionShort.text = _animalDescriptionShortDE;
            _animalDescriptionFull.text = _animalDescriptionFullDE;
        }
        else {
            _animalDescriptionShort.text = _animalDescriptionShortEN;
            _animalDescriptionFull.text = _animalDescriptionFullEN;
        }

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

    public void SetGerman() {
        german = true;
        germanButton.interactable = false;
        englishButton.interactable = true;

        _animalDescriptionShort.text = _animalDescriptionShortDE;
        _animalDescriptionFull.text = _animalDescriptionFullDE;
        backSmallPanel.GetComponentInChildren<Text>().text = "Zurück";
        more.GetComponentInChildren<Text>().text = "Mehr";
        backBigPanel.GetComponentInChildren<Text>().text = "Zurück";
        group.GetComponentInChildren<Text>().text = "Gruppe";
    }

    public void SetEnglish() {
        german = false;
        germanButton.interactable = true;
        englishButton.interactable = false;

        _animalDescriptionShort.text = _animalDescriptionShortEN;
        _animalDescriptionFull.text = _animalDescriptionFullEN;
        backSmallPanel.GetComponentInChildren<Text>().text = "Back";
        more.GetComponentInChildren<Text>().text = "More";
        backBigPanel.GetComponentInChildren<Text>().text = "Back";
        group.GetComponentInChildren<Text>().text = "Group";
    }

    private IEnumerator CloseP() {
        yield return new WaitForSecondsRealtime(0.1f);
        TouchControlls.instance.detailedView = false;
    }

}
