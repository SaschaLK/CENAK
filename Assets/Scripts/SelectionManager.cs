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
    public Button _animalNameBig;
    public Text _animalNameSubtextBig;
    public Button _animalImageBig;
    public Text _animalDescription;
    [HideInInspector] public string _animalDescriptionFullDE;
    [HideInInspector] public string _animalDescriptionFullEN;
    private string animalDescriptionBackupDE;
    private string animalDescriptionBackupEN;

    [Space(10)]
    public List<Button> animalGroupButtons;
    [HideInInspector] public List<string> _animalGroups;
    public Color selectedButtonColor;
    public Color standardButtonColor;

    private Button selectedButton;

    private void Awake() {
        instance = this;
    }

    public void SetAnimal(string animalName, string animalNameSubtext, Sprite animalImage, string animalDescriptionFullDE, string animalDescriptionFullEN, List<string> animalGroups) {
        _animalNameBig.GetComponentInChildren<Text>().text = animalName;
        _animalNameSubtextBig.text = animalNameSubtext;
        _animalImageBig.GetComponent<Image>().sprite = animalImage;
        _animalDescriptionFullDE = animalDescriptionFullDE;
        _animalDescriptionFullEN = animalDescriptionFullEN;
        _animalGroups = animalGroups;

        animalDescriptionBackupDE = animalDescriptionFullDE;
        animalDescriptionBackupEN = animalDescriptionFullEN;

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

        if(selectedButton != null) {
            selectedButton.GetComponent<Image>().color = standardButtonColor;
            selectedButton.GetComponentInChildren<Text>().color = Color.white;
        }
        selectedButton = group;
        selectedButton.GetComponent<Image>().color = selectedButtonColor;
        selectedButton.GetComponentInChildren<Text>().color = Color.black;
    }

    public void ClearGroupSelection() {
        foreach(Button groupButton in animalGroupButtons) {
            groupButton.GetComponent<Image>().color = standardButtonColor;
            groupButton.GetComponentInChildren<Text>().color = Color.white;
        }

        if (german) {
            _animalDescription.text = animalDescriptionBackupDE;
        }
        else {
            _animalDescription.text = animalDescriptionBackupEN;
        }
    }

    public void OpenBigInfo() {
        panelBig.SetActive(true);
    }

    public void ClosePanel() {
        panelBig.SetActive(false);
        ClearGroupSelection();
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
        MainCameraController.instance.detailedView = false;
    }

}
