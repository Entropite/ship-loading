using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour {
    Conveyor conveyor;
    Vector3 normal;
    void FixedUpdate() {
        if (conveyor != null && conveyor.movement_enabled) {
            transform.Translate(conveyor.direction * 0.1f);
        }
    }

    void OnCollisionEnter(Collision c) {
        if (c.gameObject.CompareTag("Conveyor")) {
            conveyor = c.gameObject.GetComponent<Conveyor>();
            normal = c.GetContact(0).normal;
            transform.up = normal;
        }
    }

}
