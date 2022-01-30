using DG.Tweening;
using UnityEngine;

public class Ennemy : MonoBehaviour {
    private float _detectionDistance = 30;
    [SerializeField] private float speed = 10;
    [SerializeField] private float rotationSpeed = 25;


    private HealthManager _healthManager;

    private Vector2 _direction;

    private void FixedUpdate() {
        if (_healthManager.IsDead()) return;

        if (Vector3.Distance(Player.Instance.transform.position, transform.position) > _detectionDistance * (transform.localScale.x)) return;

        var player = Player.Instance.transform.position;

        transform.position = Vector2.MoveTowards(transform.position, player, speed * Time.deltaTime);

        _direction = player - transform.position;
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    private void Awake() {
        _healthManager = GetComponent<HealthManager>();
        _healthManager.OnDead += OnDead;

        _healthManager.SetMaxHealth(transform.localScale.x * 100);
    }

    private void OnDead() {
        Manager.IncreaseScore(27);
        transform.DOScale(0, 1).OnComplete(() => { Destroy(gameObject); });
    }
}