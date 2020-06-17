using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour {

    public static SelectionManager instance;

    [Space(10)]
    public bool german;
    public Button germanButton;
    public Button englishButton;

    [Space(10)]
    [SerializeField] private GameObject panelSmall;
    public Button more;
    [SerializeField] private GameObject panelBig;

    [Space(10)]
    public Text _animalNameBig;
    public Text _animalNameSubtextBig;
    public Text _animalNameSmall;
    public Text _animalNameSubtextSmall;
    public Image _animalImageBig;
    public Image _animalImageSmall;
    public Text _animalDescriptionShort;
    public Text _animalDescriptionFull;
    [HideInInspector] public string _animalDescriptionShortDE;
    [HideInInspector] public string _animalDescriptionShortEN;
    [HideInInspector] public string _animalDescriptionFullDE;
    [HideInInspector] public string _animalDescriptionFullEN;

    [Space(10)]
    public List<Button> animalGroupButtons;
    [HideInInspector] public List<string> _animalGroups;

    private void Awake() {
        instance = this;
    }

    public void SetAnimal(string animalName, string animalNameSubtext, Sprite animalImage, string animalDescriptionShortDE, string animalDescriptionShortEN, string animalDescriptionFullDE, string animalDescriptionFullEN, List<string> animalGroups) {
        _animalNameBig.text = animalName;
        _animalNameSubtextBig.text = animalNameSubtext;
        _animalNameSmall.text = animalName;
        _animalNameSubtextSmall.text = animalNameSubtext;
        _animalImageBig.sprite = animalImage;
        _animalImageSmall.sprite = animalImage;
        _animalDescriptionShortDE = animalDescriptionShortDE;
        _animalDescriptionShortEN = animalDescriptionShortEN;
        _animalDescriptionFullDE = animalDescriptionFullDE;
        _animalDescriptionFullEN = animalDescriptionFullEN;
        _animalGroups = animalGroups;

        if (german) {
            _animalDescriptionShort.text = _animalDescriptionShortDE;
            _animalDescriptionFull.text = _animalDescriptionFullDE;
        }
        else {
            _animalDescriptionShort.text = _animalDescriptionShortEN;
            _animalDescriptionFull.text = _animalDescriptionFullEN;
        }

        for(int i = 0; i < 4; i++) {
            if(i < _animalGroups.Count) {
                animalGroupButtons[i].GetComponentInChildren<Text>().text = _animalGroups[i]; 
                animalGroupButtons[i].gameObject.SetActive(true);
            }
            else {
                animalGroupButtons[i].gameObject.SetActive(false);
            }
        }

        TouchControlls.instance.detailedView = true;
        panelSmall.SetActive(true);
    }

    public void SetGroupText(Button group) {
        string groupName = group.GetComponentInChildren<Text>().text;

        foreach(AnimalGroups.AnimalGroup animalGroup in AnimalGroups.instance.animalGroups) {
            if (groupName.Equals(animalGroup.name)) {
                _animalDescriptionFull.text = animalGroup.description;
            }
        }
    }

    public void OpenBigInfo() {
        panelSmall.SetActive(false);
        panelBig.SetActive(true);
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
        more.GetComponentInChildren<Text>().text = "Mehr";
    }

    public void SetEnglish() {
        german = false;
        germanButton.interactable = true;
        englishButton.interactable = false;

        _animalDescriptionShort.text = _animalDescriptionShortEN;
        _animalDescriptionFull.text = _animalDescriptionFullEN;
        more.GetComponentInChildren<Text>().text = "More";
    }

    private IEnumerator CloseP() {
        yield return new WaitForSecondsRealtime(0.1f);
        TouchControlls.instance.detailedView = false;
    }

}
