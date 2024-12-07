using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour {
    Conveyor conveyor;
    Conveyor prevConveyor;

    Vector3 normal;
    void FixedUpdate() {
        if (conveyor != null && conveyor.movement_enabled) {
            transform.Translate(conveyor.direction * 0.1f);
        }

        if (transform.position.y < -10.0f) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision c) {
        if (c.gameObject.CompareTag("Conveyor")) {
            Conveyor temp = c.gameObject.GetComponent<Conveyor>();
            if (temp != prevConveyor && temp != conveyor) {
                prevConveyor = conveyor;
                conveyor = temp;
                normal = c.GetContact(0).normal;
                transform.up = normal;
            }
        }
    }
}
