using System;
using UnityEngine;

[DisallowMultipleComponent]
public class Player : MonoBehaviour {
    private Rigidbody2D _rb;
    [SerializeField, Range(0, 50)] private float force = 10;

    public static Player Instance;

    private void Awake() {
        Instance = this;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        transform.RotateToLookTarget(Input.mousePosition);

        if (Input.GetAxis("Vertical") > 0) {
            _rb.AddForce(transform.right * force * Time.deltaTime * 10 , ForceMode2D.Force);
        }
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Bonus")) {
            
        }
    }
}