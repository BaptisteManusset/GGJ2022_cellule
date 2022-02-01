using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pique : MonoBehaviour {
    private Mob _me;
    private Collider2D _boxCollider2D;

    private void Awake() {
        _boxCollider2D = GetComponent<Collider2D>();
        _boxCollider2D.isTrigger = true;


        _me = GetComponentInParent<Mob>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.CompareTag("Body")) return;

        OnCollision(other);
    }

    private void OnCollision(Collider2D other) {
        Mob attacked = other.GetComponent<Mob>() ?? other.GetComponentInParent<Mob>();
        if (attacked == null) return; // si l'attaqué existe
        if (attacked.team == _me.team) return; // si l'attaqué n'est pas dans la meme team que moi
        attacked._healthManager.TakeDamage(2, _me);
    }
}