using UnityEngine;

[DisallowMultipleComponent]
public class BodyElement : MonoBehaviour {
    public Transform target;
    private Vector2 direction;
    private const float rotationSpeed = 25;


    private void FixedUpdate() {
        direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}