using System;
using UnityEngine;

[DisallowMultipleComponent]
public class Bouche : MonoBehaviour {
    private Mob _me;
    private BoxCollider2D _boxCollider2D;

    private void Awake() {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _boxCollider2D.isTrigger = true;
        
        
        _me = GetComponentInParent<Mob>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.CompareTag("Body")) return;

        OnCollision(other);
    }

    private void OnCollision(Collider2D other) {
        var attacked = other.GetComponent<Mob>();
        if (attacked == null) return; // si l'attaqué existe
        if (attacked.team == _me.team) return; // si l'attaqué n'est pas dans la meme team que moi
        if (_me.IsComestible(attacked.type) == false) return; // si l'attaqué est comestible pour moi


        attacked._healthManager.TakeDamage(1, _me);


        if (!_me.isPlayer) return;

        // Debug.Log($"is player : {gameObject} attack : {other}");
        _me.Eat();
    }
}