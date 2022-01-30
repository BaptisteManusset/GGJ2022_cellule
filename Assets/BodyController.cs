using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[DisallowMultipleComponent]
public class BodyController : MonoBehaviour {
    // [SerializeField] private Transform parent;
    // [SerializeField] private BodyPart bodypartPrefab;
    //
    // [SerializeField] public List<BodyPart> bodyParts = new List<BodyPart>();
    //
    // [SerializeField] private int quantity = 10;
    //
    //
    // [SerializeField] Rigidbody2D _rb;
    //
    // private void Awake() {
    //     _rb = GetComponent<Rigidbody2D>();
    //     BodyPart slt = Instantiate(bodypartPrefab, parent);
    //     slt.Setup(this, null);
    //
    //     for (int i = 1; i < quantity; i++) {
    //         var previous = bodyParts[i - 1].GetComponent<Rigidbody2D>();
    //
    //         slt = Instantiate(bodypartPrefab, previous.transform.position - previous.transform.right, Quaternion.identity, parent);
    //         slt.Setup(this, previous);
    //     }
    // }
    //
    //
    // [ContextMenu("add Part")]
    // public void AddPart() {
    //     BodyPart slt = Instantiate(bodypartPrefab, parent);
    //     slt.Setup(this, bodyParts[bodyParts.Count - 2].GetComponent<Rigidbody2D>());
    // }
    
    
    
}