using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    private void FixedUpdate() {
        Vector3 pos = transform.position;
        pos.x = Player.Instance.transform.position.x;
        pos.y = Player.Instance.transform.position.y;
        transform.position = pos;
    }
}