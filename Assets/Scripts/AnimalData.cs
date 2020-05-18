using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Animal", menuName = "Animal")]
public class AnimalData : ScriptableObject {

    public new string name;
    public string animalGroup;
    public Sprite picture;
    [TextArea] public string shortDescription;
    [TextArea] public string longDescription;

}
