using UnityEngine;

public class Ennemy : MonoBehaviour {
    private float _detectionDistance = 10;
    [SerializeField] private float speed = 10;

    private void FixedUpdate() {
        if (Vector3.Distance(Player.Instance.transform.position, transform.position) > _detectionDistance) return;

        var player = Player.Instance.transform.position;

        transform.position = Vector2.MoveTowards(transform.position, player, speed * Time.deltaTime);
        
        float angle = 0;
         
        Vector3 relative = transform.InverseTransformPoint(player);
        angle = Mathf.Atan2(relative.x, relative.y)*Mathf.Rad2Deg;
        transform.Rotate(0,0, -angle);
    }
}