using UnityEngine;

public class BodyPartAnchor : MonoBehaviour {
    [SerializeField] private GameObject obj;

    private void OnMouseDown() {
        Instantiate(obj, transform);
    }
}