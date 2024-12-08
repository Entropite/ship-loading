using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : MonoBehaviour {
    public GameObject crate_prefab;
    private int last_t = 0;
    public bool spawning_enabled;

    void Update() {
        int t = (int) Time.realtimeSinceStartup;

        if (t != last_t && t % 3 == 0 && spawning_enabled) {
            GameObject g = Instantiate(crate_prefab);
            float n = Random.Range(0.5f, 0.7f);
            g.transform.localScale = new Vector3(n, n, n);
            g.transform.SetPositionAndRotation(this.transform.position, Quaternion.identity);
            last_t = t;
        }
    }
}
