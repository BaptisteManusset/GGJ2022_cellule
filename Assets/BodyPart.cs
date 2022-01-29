using UnityEngine;

[DisallowMultipleComponent]
public class BodyPart : MonoBehaviour {
    [SerializeField] private bool haveNageoire = false;
    [SerializeField] private GameObject nageoire;


    public bool HaveNageoire {
        get => haveNageoire;

        set {
            haveNageoire = value;
            nageoire.SetActive(haveNageoire);
        }
    }
}