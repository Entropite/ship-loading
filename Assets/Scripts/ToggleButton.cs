using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum ButtonType {
    CONVEYOR,
    SPAWNER
}
public class ToggleButton : MonoBehaviour {
    public TextMeshPro tmp;
    public ButtonType type;

    private void OnTriggerEnter(Collider other) {
        if (type == ButtonType.CONVEYOR) {
            GameObject[] conveyors = GameObject.FindGameObjectsWithTag("Conveyor");
            bool status = false;
            foreach (GameObject conveyor in conveyors) {
                Conveyor c = conveyor.GetComponent<Conveyor>();
                c.movement_enabled = !c.movement_enabled;
                status = c.movement_enabled;
            }

            tmp.text = "Conveyor status: " + (status ? "ON" : "OFF");
        } else if (type == ButtonType.SPAWNER) {
            GameObject obj = GameObject.FindGameObjectWithTag("Spawner");
            CrateSpawner spawner = obj.GetComponent<CrateSpawner>();
            spawner.spawning_enabled = !spawner.spawning_enabled;

            tmp.text = "Freight source: " + (spawner.spawning_enabled ? "ON" : "OFF");
        }
    }
}
