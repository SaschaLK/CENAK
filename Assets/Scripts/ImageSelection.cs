using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSelection : MonoBehaviour {

    [SerializeField] private AnimalData animalData;

    public void OpenPanel() {
        string animalSubtext = "<i>" + animalData.latName + "</i> " + animalData.descriptor;
        SelectionManager.instance.SetAnimal(name, animalSubtext, GetComponent<SpriteRenderer>().sprite, animalData.shortDescriptionDE, animalData.shortDescriptionEN, animalData.longDescriptionDE, animalData.longDescriptionEN, animalData.animalGroups);
    }
}
