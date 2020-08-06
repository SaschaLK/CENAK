using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using System;

public class SelectionManager : MonoBehaviour {

#pragma warning disable 0649

    public static SelectionManager instance;

    [Space(10)]
    public bool german;
    public Button germanButton;
    public Button englishButton;

    [Space(10)]
    [SerializeField] private GameObject panelBig;

    [Space(10)]
    public Text _animalNameBig;
    public Text _animalNameSubtextBig;
    public Image _animalImageBig;
    public Text _animalDescription;
    [HideInInspector] public string _animalDescriptionFullDE;
    [HideInInspector] public string _animalDescriptionFullEN;

    [Space(10)]
    public List<Button> animalGroupButtons;
    [HideInInspector] public List<string> _animalGroups;

    private void Awake() {
        instance = this;
    }

    public void SetAnimal(string animalName, string animalNameSubtext, Sprite animalImage, string animalDescriptionFullDE, string animalDescriptionFullEN, List<string> animalGroups) {
        _animalNameBig.text = animalName;
        _animalNameSubtextBig.text = animalNameSubtext;
        _animalImageBig.sprite = animalImage;
        _animalDescriptionFullDE = animalDescriptionFullDE;
        _animalDescriptionFullEN = animalDescriptionFullEN;
        _animalGroups = animalGroups;

        if (german) {
            _animalDescription.text = _animalDescriptionFullDE;
        }
        else {
            _animalDescription.text = _animalDescriptionFullEN;
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

        //TouchControlls.instance.detailedView = true;
        MainCameraController.instance.detailedView = true;
        OpenBigInfo();
    }

    public void SetGroupText(Button group) {
        string groupName = group.GetComponentInChildren<Text>().text;
        string groupNameClean = Regex.Replace(groupName, @"\s", "");

        foreach(AnimalGroups.AnimalGroup animalGroup in AnimalGroups.instance.animalGroups) {
            string _groupNameClean = Regex.Replace(animalGroup.name, @"\s", "");

            if(string.Equals(groupNameClean, _groupNameClean)) {
                _animalDescriptionFullDE = animalGroup.descriptionDE;
                _animalDescriptionFullEN = animalGroup.descriptionEN;

                if (german) {
                    _animalDescription.text = _animalDescriptionFullDE;
                }
                else {
                    _animalDescription.text = animalGroup.descriptionEN;
                }
                break;
            }
        }
    }

    public void OpenBigInfo() {
        panelBig.SetActive(true);
    }

    public void ClosePanel() {
        panelBig.SetActive(false);
        StartCoroutine(CloseP());
    }

    public void SetGerman() {
        german = true;
        germanButton.interactable = false;
        englishButton.interactable = true;

        _animalDescription.text = _animalDescriptionFullDE;
    }

    public void SetEnglish() {
        german = false;
        germanButton.interactable = true;
        englishButton.interactable = false;

        _animalDescription.text = _animalDescriptionFullEN;
    }

    private IEnumerator CloseP() {
        yield return new WaitForSecondsRealtime(0.1f);
        //TouchControlls.instance.detailedView = false;
        MainCameraController.instance.detailedView = false;
    }

}
