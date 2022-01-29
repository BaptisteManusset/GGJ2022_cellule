using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(HealthManager))]
[DisallowMultipleComponent]
public class Mob : MonoBehaviour {
    public bool isPlayer = false;

    public LifeType type = LifeType.viande;
    public HealthManager.Team team = HealthManager.Team.ennemy;

    [Header("Nourriture")] [FormerlySerializedAs("lifeType")] public LifeType Regime = LifeType.viande;


    internal HealthManager _healthManager;


    private void Awake() {
        _healthManager = GetComponent<HealthManager>();

        if (_healthManager == null) Debug.LogError("il n'y a pas de HealthManager", gameObject);
    }

    public void Eat() {
       // Debug.Log("eat");

        _healthManager.IncreaseHealth();
    }


    public bool IsComestible(LifeType lifeType) {
        return Regime.HasFlag(lifeType);
    }
}