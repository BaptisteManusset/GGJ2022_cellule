﻿using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class HealthManager : MonoBehaviour, IDamageable {
    private Rigidbody2D rb;
    private Mob _me;

    [SerializeField] private float currentHealth = -1;
    [SerializeField] public float maxHealth = 100;


    private bool _alreadyDead;


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
                rb.DOKill();
                OnDead?.Invoke();
                _alreadyDead = true;
            }
    }

    public bool TakeDamage(float value, Mob agressor) {

        rb.PunchOnCollision(agressor.transform);
        SetHealth(currentHealth - value);
        return true;
    }

    public void IncreaseHealth(float value = 1) {
        SetHealth(currentHealth + value);
    }
}

public interface IDamageable {
    bool TakeDamage(float value, Mob agressor);
}