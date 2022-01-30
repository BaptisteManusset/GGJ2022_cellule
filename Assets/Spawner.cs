using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour {
    [SerializeField] private int vegetalCount = 10;
    [SerializeField] private List<GameObject> vegetals;

    [Space] [SerializeField] private int animalCount = 10;
    [SerializeField] private List<GameObject> animals;

    [Space] [SerializeField] private float radius = 100;
    [Space] [SerializeField] private float respawnRadius = 10;


    [SerializeField] private Transform parent;

    private void Awake() {
        for (int i = 0; i < vegetalCount; i++) {
            var m = Instantiate(Tools.GetRandomItem(vegetals));
            m.transform.position = Random.insideUnitCircle * radius;
        }


        for (int i = 0; i < animalCount; i++) {
            var m = Instantiate(Tools.GetRandomItem(animals));
            m.transform.position = Random.insideUnitCircle * radius;
        }


        InvokeRepeating(nameof(SpawnMobAndVegetal), 10, 10);
    }

    public void SpawnMobAndVegetal() {
        for (int i = 0; i < Random.Range(1, 2); i++) {
            Instantiate(Tools.GetRandomItem(vegetals), RandomPositionOutsideCamera(respawnRadius), quaternion.identity, parent);
        }

        for (int i = 0; i < Random.Range(1, 3); i++) {
            GameObject obk = Instantiate(Tools.GetRandomItem(animals), RandomPositionOutsideCamera(respawnRadius), quaternion.identity, parent);
            obk.transform.localScale = Vector3.one + Vector3.one * (Manager.Instance.Score * .01f);
        }
    }

    private static Vector2 RandomPositionOutsideCamera(float respawnRadius) {
        float spawnY = Mathf.Sign(Random.Range(-1, 1)) * respawnRadius;
        float spawnX = Mathf.Sign(Random.Range(-1, 1)) * respawnRadius;

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        return spawnPosition;
    }


    private void OnDrawGizmos() {
        if (Player.Instance)
            Gizmos.DrawWireSphere(Player.Instance.transform.position, respawnRadius);
    }
}