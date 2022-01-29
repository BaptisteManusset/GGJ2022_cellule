using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] private int vegetalCount = 10;
    [SerializeField] private List<GameObject> vegetals;

    [Space] [SerializeField] private int animalCount = 10;
    [SerializeField] private List<GameObject> animals;

    [Space] [SerializeField] private float radius = 100;


    private void Awake() {
        for (int i = 0; i < vegetalCount; i++) {
            var m = Instantiate(Tools.GetRandomItem(vegetals));
            m.transform.position = Random.insideUnitCircle * radius;
        }


        for (int i = 0; i < animalCount; i++) {
            var m = Instantiate(Tools.GetRandomItem(animals));
            m.transform.position = Random.insideUnitCircle * radius;
        }
    }
}