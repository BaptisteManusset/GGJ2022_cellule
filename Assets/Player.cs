using System;
using Bonys;
using Toolbox.Procedural.Tentacle;
using UnityEngine;

[DisallowMultipleComponent]
public class Player : MonoBehaviour {
    private Rigidbody2D _rb;
    [SerializeField, Range(0, 50)] private float force = 10;

    public static Player Instance;

    [HideInInspector] public HealthManager _healthManager;
    private ProceduralSnake proceduralSnake;

    private void Awake() {
        proceduralSnake = GetComponentInChildren<ProceduralSnake>();

        _healthManager = GetComponent<HealthManager>();
        Instance = this;
        _rb = GetComponent<Rigidbody2D>();
    }

    public float rotationSpeed = 25;
    private Vector2 direction;

    void Update() {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);


        if (Input.GetAxis("Vertical") > 0) {
            _rb.AddForce(transform.right * force * Time.deltaTime * 10, ForceMode2D.Force);
        }
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Bonus")) { }
    }

    public void IncreaSize(TypeOfBodyPart pick = TypeOfBodyPart.normal) {
        proceduralSnake.AddBodyPart(pick);
    }
}