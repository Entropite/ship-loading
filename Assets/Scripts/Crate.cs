using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct ConveyorData {
    public bool has_left_collider;
    public Conveyor component;
}
public class Crate : MonoBehaviour {
    ConveyorData conveyor;
    ConveyorData prevConveyor;

    Vector3 normal;
    void FixedUpdate() {
        if (conveyor.has_left_collider && prevConveyor.has_left_collider) {
            conveyor.component     = null;
            prevConveyor.component = null;
            return;
        }

        if (conveyor.component != null && conveyor.component.movement_enabled) {
            transform.Translate(conveyor.component.direction * 0.08f);
        }

        if (transform.position.y < -10.0f) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision c) {
        if (c.gameObject.CompareTag("Conveyor")) {
            Conveyor temp = c.gameObject.GetComponent<Conveyor>();
            if (temp != prevConveyor.component && temp != conveyor.component) {
                prevConveyor.component         = conveyor.component;
                prevConveyor.has_left_collider = conveyor.has_left_collider;
                conveyor.has_left_collider     = false;
                conveyor.component             = temp;
                normal                         = c.GetContact(0).normal;
                transform.up                   = normal;

                if (prevConveyor.component) {
                    transform.Translate(prevConveyor.component.direction * 0.19f);
                }
                //transform.Translate(conveyor.component.direction * 0.19f);
            }
        }
    }

    private void OnCollisionExit(Collision c) {
        if (c.gameObject.CompareTag("Conveyor")) {
            Conveyor collided_conveyor = c.gameObject.GetComponent<Conveyor>();
            if      (collided_conveyor == conveyor.component)     conveyor.has_left_collider     = true;
            else if (collided_conveyor == prevConveyor.component) prevConveyor.has_left_collider = true;
        }
    }
}
