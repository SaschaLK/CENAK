using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSelection : MonoBehaviour {

#pragma warning disable 0649

    [SerializeField] private AnimalData animalData;

    public void OpenPanel() {
        string animalSubtext = "<i>" + animalData.latName + "</i> " + animalData.descriptor;
        SelectionManager.instance.SetAnimal(name, animalSubtext, GetComponent<SpriteRenderer>().sprite, animalData.DescriptionDE, animalData.DescriptionEN, animalData.animalGroups);
    }
}
