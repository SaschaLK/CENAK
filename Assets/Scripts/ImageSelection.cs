using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSelection : MonoBehaviour {

    [SerializeField] private AnimalData animalData;

    public void OpenPanel() {
        SelectionManager.instance.SetAnimal(animalData.name, animalData.picture, animalData.shortDescriptionDE, animalData.longDescriptionDE, animalData.animalGroup);
    }
}
