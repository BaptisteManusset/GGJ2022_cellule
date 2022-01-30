using UnityEngine;

public class Ennemy : MonoBehaviour {
    private float _detectionDistance = 10;
    [SerializeField] private float speed = 10;
    [SerializeField] private float rotationSpeed = 25;


    private Vector2 direction;

    private void FixedUpdate() {
        if (Vector3.Distance(Player.Instance.transform.position, transform.position) > _detectionDistance) return;

        var player = Player.Instance.transform.position;

        transform.position = Vector2.MoveTowards(transform.position, player, speed * Time.deltaTime);

        direction = player  - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}