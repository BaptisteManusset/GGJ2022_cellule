using System;
using Bonys;
using Toolbox.Procedural.Tentacle;
using UnityEngine;
using Random = UnityEngine.Random;

[DisallowMultipleComponent]
public class Player : MonoBehaviour {
    private int speedBonus = 2;

    public void IncreaseSpeedBonus() {
        speedBonus++;
    }

    private Rigidbody2D _rb;
    [SerializeField, Range(0, 50)] private float force = 10;

    private static Player _instance;

    public static Player Instance {
        get {
            _instance = FindObjectOfType<Player>();
            _instance._healthManager = _instance.GetComponent<HealthManager>();
            return _instance;
        }
    }

    [HideInInspector] public HealthManager _healthManager;
    private ProceduralSnake proceduralSnake;

    private void Awake() {
        proceduralSnake = GetComponentInChildren<ProceduralSnake>();

        _rb = GetComponent<Rigidbody2D>();
    }

    public float rotationSpeed = 25;
    private Vector2 direction;

    private void Start() {
        Collider2D[] slt = Physics2D.OverlapCircleAll(transform.position, 10);
        for (int i = slt.Length - 1; i >= 0; i--) {
            if (slt[i].GetComponent<Ennemy>()) Destroy(slt[i]);
        }
    }

    void Update() {
        if (Manager.Instance.mainMenu) return;
        if (Manager.Instance.gameOver)
            return;

        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);


        if (Input.GetAxis("Vertical") > 0) {
            _rb.AddForce(transform.right * force * Time.deltaTime * 10 * (speedBonus * .5f), ForceMode2D.Force);
        }
    }

    public void IncreaSize(TypeOfBodyPart pick = TypeOfBodyPart.normal) {
        proceduralSnake.AddBodyPart(pick);
    }
}