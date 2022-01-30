using DG.Tweening;
using UnityEngine;

[DisallowMultipleComponent]
public class BonusContainer : MonoBehaviour {
    private HealthManager _healthManager;

    private Rigidbody2D rb;

    private LifeType type = LifeType.plante;

    [SerializeField] private bool randomSize = false;

    [Space, SerializeField] Bonys.Bonus _bonus;

    private void Awake() {
        if (_bonus == null) Debug.LogError("Bonus container empty", gameObject);
        _healthManager = GetComponent<HealthManager>();
        rb = GetComponent<Rigidbody2D>();

        _healthManager.OnHealthChange += TakeDamage;
        _healthManager.OnDead += Dead;


        int health = randomSize ? Random.Range(1, 10) : 1;

        _healthManager.SetMaxHealth(health);
        transform.localScale = Scale;
    }

    public void Action() {
        if (_bonus)
            _bonus.Action();
    }

    public void TakeDamage() {
        if (!type.HasFlag(LifeType.plante)) return;
        transform.DOScale(Scale, .5f);
    }

    private void Dead() {
        Destroy(gameObject, .1f);
        transform.DOKill();
    }


    private Vector3 Scale => _healthManager.GetHealth() * Vector3.one;
}