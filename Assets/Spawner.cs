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

        for (int i = 0; i < lenght; i += count) {
            for (int j = 0; j < lenght; j += count) {
                Instantiate(Tools.GetRandomItem(vegetals), new Vector3(i - lenght / 2, j - lenght / 2), quaternion.identity, parent);
            }
        }


        InvokeRepeating(nameof(SpawnMobAndVegetal), 10, 10);
    }

    public void SpawnMobAndVegetal() {
        SpawnVegetal();

        for (int i = 0; i < Random.Range(1, 3); i++) {
            Vector2 s = RandomPositionOutsideCamera();
            if (s == Vector2.zero) return;
            GameObject obk = Instantiate(Tools.GetRandomItem(animals), s, quaternion.identity, parent);
            obk.transform.localScale = Vector3.one + Vector3.one * (Manager.Instance.Score * .01f);
        }
    }

    private void SpawnVegetal() {
        Debug.Log("spawn object");
        Vector2 s = RandomPositionOutsideCamera();
        if (s == Vector2.zero) return;
        Instantiate(Tools.GetRandomItem(vegetals), s, quaternion.identity, parent);
    }

    private void FixedUpdate() {
        int radius = 20;

        Collider2D[] colliders = new Collider2D[15];
        var position = Player.Instance.transform.position;
        int count = Physics2D.OverlapAreaNonAlloc(
            (Vector2)position + new Vector2(-radius, -radius),
            (Vector2)position + new Vector2(radius, radius), colliders);

        Debug.Log(count);
        if (count <= 10) SpawnMobAndVegetal();
    }

    // private static Vector2 RandomPositionOutsideCamera(float respawnRadius) {
    //     float spawnY = Mathf.Sign(Random.Range(-1, 1)) * respawnRadius;
    //     float spawnX = Mathf.Sign(Random.Range(-1, 1)) * respawnRadius;
    //
    //     Vector2 spawnPosition = new Vector2(spawnX, spawnY);
    //     return spawnPosition;
    // }


    private static Vector2 RandomPositionOutsideCamera() {
        Vector2 pos = Player.Instance.transform.position;

        pos.x = Mathf.Round(pos.x / 20) * 20;
        pos.y = Mathf.Round(pos.y / 20) * 20;

        Vector2 r = new Vector2(
            Random.Range(-1, 2),
            Random.Range(-1, 2));

        if (r == Vector2.zero) return Vector2.zero;
        r *= 20;


        return pos + r;
    }


    [SerializeField] int lenght = 80;

    [SerializeField] int count = 10;

    //
    private void OnDrawGizmos() {
        //     if (Player.Instance != null) {
        //         Vector2 pos = FindObjectOfType<Player>().transform.position;
        //
        //         pos.x = Mathf.Round(pos.x / 20) * 20;
        //         pos.y = Mathf.Round(pos.y / 20) * 20;
        //         Gizmos.color = Color.yellow;
        //         Gizmos.DrawWireCube(pos, Vector3.one * .5f);
        //         Gizmos.DrawLine(pos, Player.Instance.transform.position);
        //
        //         Vector2 r = new Vector2(
        //             Random.Range(-1, 2),
        //             Random.Range(-1, 2));
        //
        //         if (r == Vector2.zero) return;
        //         r *= 20;
        //         Gizmos.color = Color.magenta;
        //
        //         Gizmos.DrawLine(pos + r, Player.Instance.transform.position);
        //
        //         Gizmos.DrawSphere(pos + r, .5f);
        //     }
        //
        //
        //     for (int i = 0; i < lenght; i += count) {
        //         for (int j = 0; j < lenght; j += count) {
        //             Gizmos.DrawWireSphere(new Vector3(i - lenght / 2, j - lenght / 2), 1);
        //         }
        //     }
    }
}