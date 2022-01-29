using DG.Tweening;
using UnityEngine;

[DisallowMultipleComponent]
public class Plant : MonoBehaviour {
    private HealthManager _healthManager;

    private Rigidbody2D rb;

    private LifeType type = LifeType.plante;

    private void Awake() {
        _healthManager = GetComponent<HealthManager>();
        rb = GetComponent<Rigidbody2D>();

        _healthManager.OnHealthChange += TakeDamage;
        _healthManager.OnDead += Dead;

        _healthManager.SetMaxHealth(Random.Range(1, 10));
        transform.localScale = Scale;
    }

    public void TakeDamage() {
        if (!type.HasFlag(LifeType.plante)) return;
        transform.DOScale(Scale, .5f);
    }

    private void Dead() {
        Destroy(gameObject, .1f);
        transform.DOKill();
    }


    private Vector3 Scale => _healthManager.GetHealth() * 0.5f * Vector3.one;
}