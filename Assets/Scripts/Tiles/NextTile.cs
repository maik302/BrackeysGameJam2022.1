using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTile : MonoBehaviour {

    void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Player")) {
            GroundSpawner.Instance.SpawnTile();
            Destroy(gameObject, 2);
        }
    }

}
