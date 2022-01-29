using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public static class Tools {
    public static void RotateToLookTarget(this Transform transform, Vector3 target) {
        target.z = 0;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        target.x = target.x - objectPos.x;
        target.y = target.y - objectPos.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }


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