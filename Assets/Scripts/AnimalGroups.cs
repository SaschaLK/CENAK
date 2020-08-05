using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalGroups : MonoBehaviour {

    public static AnimalGroups instance;

    private void Awake() {
        instance = this;
    }

    public List<AnimalGroup> animalGroups = new List<AnimalGroup>();

    [System.Serializable] public class AnimalGroup {
        public string name;
        [TextArea] public string descriptionDE;
        [TextArea] public string descriptionEN;
    }
}
