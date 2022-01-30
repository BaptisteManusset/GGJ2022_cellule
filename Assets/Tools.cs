using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public static class Tools {


    public static GameObject GetRandomItem(List<GameObject> listToRandomize) {
        int randomNum = Random.Range(0, listToRandomize.Count);

        return listToRandomize[randomNum];
    }


    public static void PunchOnCollision(this Rigidbody2D rb, Transform collider, float magnitude = 100) {
        // calculate force vector
        var force = rb.transform.position - collider.position;
        // normalize force vector to get direction only and trim magnitude
        force.Normalize();
        rb.AddForce(force * magnitude);
    }
}