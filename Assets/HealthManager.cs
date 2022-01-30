using System;
using System.Diagnostics.SymbolStore;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class HealthManager : MonoBehaviour, IDamageable {
    private Rigidbody2D rb;
    private Mob _me;

    [SerializeField] private float currentHealth = -1;
    [SerializeField] public float maxHealth = 100;


    private bool _alreadyDead;


    public bool playVfx = false;

    public enum Team {
        player = 0,
        ennemy = 1,
        neutral = 2
    }

    private Team _teamsInfo;

    private void Awake() {
        _me = GetComponent<Mob>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        currentHealth = maxHealth;
    }


    public UnityAction OnDead;
    public UnityAction OnHealthChange;

    public float GetHealth() {
        return currentHealth;
    }

    public bool IsDead() => _alreadyDead;

    public void SetMaxHealth(float value) {
        currentHealth = maxHealth = value;
    }

    public void SetHealth(float value) {
        if (_alreadyDead) return;

        OnHealthChange?.Invoke();


        currentHealth = value;
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        if (currentHealth <= 0)
            if (!_alreadyDead) {
                if (playVfx) VFXManager.Instance.SpawnDeath(transform);

                OnDead?.Invoke();
                _alreadyDead = true;
            }
    }

    public bool TakeDamage(float value, Mob agressor) {
        rb.PunchOnCollision(agressor.transform);

        Debug.Log(VFXManager.Instance + "  " + transform);
        if (playVfx) VFXManager.Instance.SpawnDamage(transform);

        SetHealth(currentHealth - value);
        return true;
    }

    public void IncreaseHealth(float value = 1) {
        SetHealth(currentHealth + value);
    }

    private void OnDestroy() {
        rb.DOKill();
    }
}

public interface IDamageable {
    bool TakeDamage(float value, Mob agressor);
}