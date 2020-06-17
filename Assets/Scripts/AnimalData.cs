using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Animal", menuName = "Animal")]
public class AnimalData : ScriptableObject {

    public string latName;
    public string descriptor;
    public List<string> animalGroups;
    [TextArea] public string shortDescriptionDE;
    [TextArea] public string shortDescriptionEN;
    [TextArea] public string longDescriptionDE;
    [TextArea] public string longDescriptionEN;

}
