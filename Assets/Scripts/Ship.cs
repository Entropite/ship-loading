using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ship : MonoBehaviour {
    float capacity = 0.0f;
    TextMeshPro t;
    private void Start() {
        t = GetComponentInChildren<TextMeshPro>();
    }
    private void OnCollisionEnter(Collision c) {
        if (c.gameObject.CompareTag("Crate")) {
            capacity += c.gameObject.transform.localScale.x * 1.5f;
            t.text = "Ship: " + capacity.ToString("0.00") + "%";
            Destroy(c.gameObject);
        }
    }
}
