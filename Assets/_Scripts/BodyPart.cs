using UnityEngine;

[DisallowMultipleComponent]
public class BodyPart : MonoBehaviour {
    // private BodyController _bc;
    //
    // public void Setup(BodyController bc, Rigidbody2D parent) {
    //     _bc = bc;
    //     _bc.bodyParts.Add(this);
    //
    //     var j = GetComponent<HingeJoint2D>();
    //
    //     if (parent)
    //         j.connectedBody = parent;
    // }
    //
    // private void OnDestroy() => _bc.bodyParts.Remove(this);
}