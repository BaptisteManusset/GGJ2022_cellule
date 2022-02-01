using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectorModifier : MonoBehaviour {
    public float speed = 3;

    private CircleCollider2D _circleCollider2D;

    private void Start() {
        _circleCollider2D = GetComponent<CircleCollider2D>();
    }

    void Update() {
        _circleCollider2D.radius -= Time.deltaTime * speed;

        if (_circleCollider2D.radius <= 0) Destroy(gameObject);
    }
}